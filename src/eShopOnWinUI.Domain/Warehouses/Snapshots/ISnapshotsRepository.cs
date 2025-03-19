using eShopOnWinUI.Domain.Products;

namespace eShopOnWinUI.Domain.Warehouses.Snapshots;

public interface ISnapshotsRepository
{
    Task<Snapshot> GetLatestAsync(ProductId productId, CancellationToken cancellationToken);
}