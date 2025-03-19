using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.CQRS.Queries;
using Inventory.Application.Models;
using Inventory.Domain.Products;

namespace Inventory.Application.Features.Products.GetProductById;

internal sealed class GetProductByIdQueryHandler(IProductsRepository productsRepository) : IQueryHandler<GetProductByIdQuery, ProductModel?>
{
    public async Task<ProductModel?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetByIdAsync(new ProductId(query.ProductId), cancellationToken);

        if (product is null)
        {
            return null;
        }

        // TODO: Load product price from some service here
        decimal productPrice = 50;

        // TODO: Use mapping here
        var productModel = new ProductModel
        {
            Id = product.Id.Value,
            Name = product.Name,
            Category = product.Category,
            Description = product.Description,
            Price = productPrice,
            ImageSource = product.Image,
        };

        return productModel;
    }
}