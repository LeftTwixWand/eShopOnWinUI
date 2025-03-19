using System.Runtime.CompilerServices;
using eShopOnWinUI.Application.Models;
using MediatR;

namespace eShopOnWinUI.Application.Features.Product;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;

internal sealed class GetProductsStreamQueryHandler : IStreamRequestHandler<GetProductsStreamQuery, ProductModel>
{
    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStreamQuery query, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        //await foreach (var product in productsRepository.GetAllAsync(cancellationToken))
        yield return new ProductModel
        {
            Id = Guid.NewGuid(),
            Name = "Lamp 1",
            Category = "Desktop",
            ImageSource = null,
        };
    }
}