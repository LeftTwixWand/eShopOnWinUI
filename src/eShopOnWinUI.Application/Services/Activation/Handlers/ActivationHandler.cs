namespace eShopOnWinUI.Application.Services.Activation.Handlers;

/// <summary>
/// Parent class for all the ActivationHandlers with typed parameter.
/// <para>Activation handler is a way to organize step by step program launching.</para>
/// <para>Read more about the activation concept: <see href="https://github.com/microsoft/WindowsTemplateStudio/blob/dev/docs/UWP/activation.md">
/// github.com/microsoft/WindowsTemplateStudio/activation</see>.</para>
/// </summary>
/// <typeparam name="T">Type of an object, that will passed as a the parameter for activation handling.</typeparam>
public abstract class ActivationHandler<T> : IActivationHandler
        where T : class
{
    /// <inheritdoc/>
    public bool CanHandle(object args)
    {
        return args is T && CanHandleInternal(args as T);
    }

    /// <inheritdoc/>
    public async Task HandleAsync(object args)
    {
        await HandleInternalAsync(args as T);
    }

    /// <summary>
    /// Function, that incapsulates <see cref="HandleAsync(object)"/> function, and allows to use typed parameter.
    /// </summary>
    /// <param name="args">Typed argument, that can be used for object activation.</param>
    /// <returns><inheritdoc cref="IActivationHandler.HandleAsync(object)" path="/returns"/></returns>
    protected abstract Task HandleInternalAsync(T? args);

    /// <summary>
    /// Function, that incapsulates <see cref="CanHandle(object)"/> function, and allows to use typed parameter.
    /// </summary>
    /// <param name="args">Typed argument, that can be used for object activation.</param>
    /// <returns><inheritdoc cref="IActivationHandler.CanHandle(object)" path="/returns"/></returns>
    protected virtual bool CanHandleInternal(T? args)
    {
        return true;
    }
}