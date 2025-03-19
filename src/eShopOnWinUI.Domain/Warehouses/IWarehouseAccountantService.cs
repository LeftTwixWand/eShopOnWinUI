using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses.Projections;

namespace eShopOnWinUI.Domain.Warehouses;

public interface IWarehouseAccountantService
{
    Task<ActualProductQuantityProjection> GetActualProductQuantityProjection(ProductId productId, CancellationToken cancellationToken);
}