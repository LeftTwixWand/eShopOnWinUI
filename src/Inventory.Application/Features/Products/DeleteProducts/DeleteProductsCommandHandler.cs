using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.CQRS.Commands;
using Inventory.Domain.Documents;
using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Application.Features.Products.DeleteProducts;

internal sealed class DeleteProductsCommandHandler(
    IProductsRepository productsRepository,
    IOrdersRepository ordersRepository,
    IWarehousesRepository warehousesRepository,
    IWarehouseAccountantService warehouseAccountantService)
    : ICommandHandler<DeleteProductsCommand>
{
    public async Task Handle(DeleteProductsCommand command, CancellationToken cancellationToken)
    {
        var productIds = command.Products.Select(productModel => new ProductId(productModel.Id)).ToArray();

        // TODO: Move products deactivation to the domain
        var usedProducts = await ordersRepository.GetListOfUsedProducts(productIds, cancellationToken);
        var warehouses = await warehousesRepository.GetManyByIdAsync(usedProducts, cancellationToken);

        foreach (var warehouse in warehouses)
        {
            var accountant = await warehouseAccountantService.GetActualProductQuantityProjection(warehouse.ProductId, cancellationToken);
            warehouse.DeactivateProduct(accountant, DocumentId.New);
        }

        var unusedProducts = productIds.Except(usedProducts);
        foreach (var productId in unusedProducts)
        {
            await productsRepository.DeleteManyByIdAsync(productId, cancellationToken);
        }
    }
}