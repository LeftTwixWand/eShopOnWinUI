using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using eShopOnWinUI.Application.ViewModels.Generic.Messages;

namespace eShopOnWinUI.Application.ViewModels.Generic;

public abstract partial class GenericItemViewModel<TModel>(IMessenger messenger) : ObservableObject
    where TModel : ObservableObject, new()
{
    [ObservableProperty]
    private TModel item = new();

    [RelayCommand]
    protected virtual void Create()
    {
        messenger.Send(new GenericItemCreatedMessage<TModel>(Item));
    }

    [RelayCommand]
    protected virtual void Delete()
    {
        messenger.Send(new GenericItemDeletedMessage<TModel>(Item));
    }

    [RelayCommand]
    protected virtual void Update()
    {
        messenger.Send(new GenericItemUpdatedMessage<TModel>(Item));
    }
}