using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using eShopOnWinUI.Application.ViewModels.Generic.Messages;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Application.ViewModels.Generic;

public abstract partial class GenericListViewModel<TModel> : ObservableRecipient,
    IRecipient<GenericItemCreatedMessage<TModel>>,
    IRecipient<GenericItemUpdatedMessage<TModel>>,
    IRecipient<GenericItemDeletedMessage<TModel>>
    where TModel : ObservableObject, new()
{
    public ObservableCollection<TModel> Items { get; } = [];

    public virtual void Receive(GenericItemCreatedMessage<TModel> message)
    {
        Items.Add(message.Value);
    }

    public virtual void Receive(GenericItemDeletedMessage<TModel> message)
    {
        Items.Remove(message.Value);
    }

    public virtual void Receive(GenericItemUpdatedMessage<TModel> message)
    {
        var itemIndex = Items.IndexOf(message.Value);
        Items[itemIndex] = message.Value;
    }

    [RelayCommand]
    protected abstract void ItemClicked(ItemsViewItemInvokedEventArgs clickedItem);

    [RelayCommand]
    protected abstract void CreateNewItem();

    [RelayCommand]
    protected abstract Task DeleteItems(IReadOnlyList<object> selectedItems, CancellationToken cancellationToken);
}