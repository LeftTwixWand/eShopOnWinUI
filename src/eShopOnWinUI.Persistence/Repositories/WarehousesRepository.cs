using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses;
using eShopOnWinUI.Domain.Warehouses.Snapshots;

namespace eShopOnWinUI.Persistence.Repositories;

internal sealed class WarehousesRepository : IWarehousesRepository
{
    // Add optional includeEvents and the implementation should include snapshots logic
    public Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Warehouse> GetFromSnapshotAsync(ProductId productId, Snapshot snapshot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Warehouse>> GetManyByIdAsync(List<ProductId> usedProducts, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}