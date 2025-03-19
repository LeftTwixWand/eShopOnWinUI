using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Application.ViewModels.Generic.Messages;

public sealed class GenericItemCreatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemCreatedMessage(TModel value)
        : base(value)
    {
    }
}