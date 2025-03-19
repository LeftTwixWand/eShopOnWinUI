using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Inventory.Application.ViewModels.Generic.Messages;

public sealed class GenericItemUpdatedMessage<TModel>(TModel value) : ValueChangedMessage<TModel>(value)
{
}