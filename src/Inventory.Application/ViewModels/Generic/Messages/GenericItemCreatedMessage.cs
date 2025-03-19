using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Inventory.Application.ViewModels.Generic.Messages;

public sealed class GenericItemCreatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemCreatedMessage(TModel value)
        : base(value)
    {
    }
}