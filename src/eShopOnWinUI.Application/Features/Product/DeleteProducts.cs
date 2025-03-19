using eShopOnWinUI.Application.CQRS.Commands;
using eShopOnWinUI.Application.Models;
using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Orders;
using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses;
using FluentValidation;

namespace eShopOnWinUI.Application.Features.Product;

internal sealed record DeleteProductsCommand(ProductModel[] Products) : CommandBase;

internal sealed partial class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsCommandValidator()
    {
        RuleFor(command => command.Products)
            .NotNull()
            .NotEmpty();
    }
}

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