using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Inventory.Application.ViewModels.Generic.Messages;

public sealed class GenericItemDeletedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemDeletedMessage(TModel value)
        : base(value)
    {
    }
}