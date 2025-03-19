using System.Threading;
using System.Threading.Tasks;

namespace eShopOnWinUI.Infrastructure.Services.UnitOfWorks.DataStorage;

/// <summary>
/// Encapsulation of the current data storage.
/// <para/>
/// Needed for saving the data, that was added through the repositories.
/// </summary>
public interface IDataStorage
{
    /// <summary>
    /// Saves the data, that was added through the repositories.
    /// </summary>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous save operation.
    /// The task result contains the number of state entries written to the underlying data storage.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}