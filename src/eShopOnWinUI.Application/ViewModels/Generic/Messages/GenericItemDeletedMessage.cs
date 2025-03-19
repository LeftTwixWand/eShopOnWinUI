using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Application.ViewModels.Generic.Messages;

public sealed class GenericItemDeletedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemDeletedMessage(TModel value)
        : base(value)
    {
    }
}