using eShopOnWinUI.Domain.Products;

namespace eShopOnWinUI.Domain.Orders;

public interface IOrdersRepository
{
    Task<List<ProductId>> GetListOfUsedProducts(ProductId[] products, CancellationToken cancellationToken);
}