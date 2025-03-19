using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses.Projections;
using eShopOnWinUI.Domain.Warehouses.Snapshots;

namespace eShopOnWinUI.Domain.Warehouses;

public sealed class WarehouseAccountantService : IWarehouseAccountantService
{
    private readonly IWarehousesRepository _warehousesRepository;
    private readonly ISnapshotsRepository _snapshotsRepository;

    public WarehouseAccountantService(IWarehousesRepository warehousesRepositor, ISnapshotsRepository snapshotsRepository)
    {
        _warehousesRepository = warehousesRepositor;
        _snapshotsRepository = snapshotsRepository;
    }

    public async Task<ActualProductQuantityProjection> GetActualProductQuantityProjection(ProductId productId, CancellationToken cancellationToken)
    {
        var snapshot = await _snapshotsRepository.GetLatestAsync(productId, cancellationToken);
        var warehouse = await _warehousesRepository.GetFromSnapshotAsync(productId, snapshot, cancellationToken);

        return new ActualProductQuantityProjection(warehouse.DomainEvents, snapshot);
    }
}