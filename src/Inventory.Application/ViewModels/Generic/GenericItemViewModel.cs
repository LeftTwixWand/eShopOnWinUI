using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Inventory.Application.ViewModels.Generic.Messages;

namespace Inventory.Application.ViewModels.Generic;

public abstract partial class GenericItemViewModel<TModel> : ObservableObject
    where TModel : ObservableObject, new()
{
    private readonly IMessenger _messenger;

    [ObservableProperty]
    private TModel item = new();

    public GenericItemViewModel(IMessenger messenger)
    {
        _messenger = messenger;
    }

    [RelayCommand]
    protected virtual void Create()
    {
        _messenger.Send(new GenericItemCreatedMessage<TModel>(Item));
    }

    [RelayCommand]
    protected virtual void Delete()
    {
        _messenger.Send(new GenericItemDeletedMessage<TModel>(Item));
    }

    [RelayCommand]
    protected virtual void Update()
    {
        _messenger.Send(new GenericItemUpdatedMessage<TModel>(Item));
    }
}