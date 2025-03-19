namespace eShopOnWinUI.Domain.Products;

public interface IProductsRepository
{
    IAsyncEnumerable<Product> GetAllAsync(CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellationToken);

    Task DeleteByIdAsync(ProductId id, CancellationToken cancellationToken);

    Task DeleteManyByIdAsync(ProductId productId, CancellationToken cancellationToken);
}