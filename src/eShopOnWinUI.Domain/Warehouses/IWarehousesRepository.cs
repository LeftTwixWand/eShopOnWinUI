using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses.Snapshots;

namespace eShopOnWinUI.Domain.Warehouses;

public interface IWarehousesRepository
{
    Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken);

    Task<Warehouse> GetFromSnapshotAsync(ProductId productId, Snapshot snapshot, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Warehouse>> GetManyByIdAsync(List<ProductId> usedProducts, CancellationToken cancellationToken);
}