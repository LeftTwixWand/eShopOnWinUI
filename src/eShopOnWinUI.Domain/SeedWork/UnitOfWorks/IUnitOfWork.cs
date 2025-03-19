namespace eShopOnWinUI.Domain.SeedWork.UnitOfWorks;

/// <summary>
/// Abstraction for DDD unit of work pattern.
/// <para><see href="http://www.reflectivesoftware.com/2015/07/26/unit-of-work-entity-framework-unity-ddd-hexagonal-onion/">Read more about Unit of work pattern</see>.</para>
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Logical finish of a domain operation.
    /// <para>By default, it rises all the domain events from domain entity objects. And saves changes, made in the repositories.</para>
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for operation discarding.</param>
    /// <returns>Status of operation. TODO: Update to count of affected records.</returns>
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}