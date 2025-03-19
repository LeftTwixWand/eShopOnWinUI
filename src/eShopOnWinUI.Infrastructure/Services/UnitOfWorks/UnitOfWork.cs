using eShopOnWinUI.Domain.SeedWork.Events;
using eShopOnWinUI.Domain.SeedWork.UnitOfWorks;
using eShopOnWinUI.Infrastructure.Services.UnitOfWorks.DataStorage;

namespace eShopOnWinUI.Infrastructure.Services.UnitOfWorks;

public partial class UnitOfWork(IDataStorage dataStorageDispatcher, IDomainEventsDispatcher domainEventsDispatcher) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        await domainEventsDispatcher.DispatchEventsAsync(cancellationToken);

        return await dataStorageDispatcher.SaveChangesAsync(cancellationToken);
    }
}