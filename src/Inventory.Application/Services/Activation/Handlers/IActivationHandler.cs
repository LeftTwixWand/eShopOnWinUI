using System.Threading.Tasks;

namespace Inventory.Application.Services.Activation.Handlers;

/// <summary>
/// An abstractions for all the activation handlers.
/// </summary>
public interface IActivationHandler
{
    /// <summary>
    /// Checks, that current handler can be activated.
    /// </summary>
    /// <param name="args">Argument, that can be used for object activation.</param>
    /// <returns>True, if activation can be handled successfully.</returns>
    bool CanHandle(object args);

    /// <summary>
    /// Trying to activate current handler.
    /// </summary>
    /// <param name="args">Argument, that can be used for object activation.</param>
    /// <returns>Task, that will be complete, when the current activation handler finished its job.</returns>
    Task HandleAsync(object args);
}