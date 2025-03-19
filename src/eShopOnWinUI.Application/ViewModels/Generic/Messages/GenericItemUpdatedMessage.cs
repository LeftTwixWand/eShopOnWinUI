using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Application.ViewModels.Generic.Messages;

public sealed class GenericItemUpdatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemUpdatedMessage(TModel value)
        : base(value)
    {
    }
}