﻿using BuildingBlocks.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DataStorageDispatching;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using HarabaSourceGenerators.Common.Attributes;

namespace BuildingBlocks.Infrastructure.Domain.UnitOfWorks;

[Inject]
public partial class UnitOfWork : IUnitOfWork
{
    private readonly IDataStorageDispatcher _dataStorageDispatcher;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        _domainEventsDispatcher.DispatchEventsAsync(cancellationToken);

        return _dataStorageDispatcher.SaveChangesAsync(cancellationToken);
    }
}