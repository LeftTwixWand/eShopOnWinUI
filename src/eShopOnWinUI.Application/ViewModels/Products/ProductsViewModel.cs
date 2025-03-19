using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eShopOnWinUI.Application.Features.Product;
using eShopOnWinUI.Application.Models;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.Generic;
using eShopOnWinUI.Application.ViewModels.Product;
using MediatR;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Application.ViewModels.Products;

public sealed partial class ProductsViewModel : GenericListViewModel<ProductModel>
{
    private readonly IMediator _mediator;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private bool isSelectionMode = false;

    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
    {
        _mediator = mediator;
        _navigationService = navigationService;
        IsActive = true;
    }

    protected override void ItemClicked(ItemsViewItemInvokedEventArgs args)
    {
        var clickedItem = args.InvokedItem as ProductModel;

        _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
        _navigationService.Navigate<ProductViewModel>(clickedItem.Id);
    }

    protected override void CreateNewItem()
    {
        _navigationService.Navigate<ProductViewModel>();
    }

    protected override async Task DeleteItems(IReadOnlyList<object> selectedItems, CancellationToken cancellationToken)
    {
        var selectedProducts = selectedItems.Cast<ProductModel>().ToArray();
        await _mediator.Send(new DeleteProductsCommand(selectedProducts), cancellationToken);

        foreach (var product in selectedProducts)
        {
            Items.Remove(product);
        }

        IsSelectionMode = false;
    }

    [RelayCommand]
    private async Task Loaded(CancellationToken cancellationToken)
    {
        if (Items.Count > 0)
        {
            return;
        }

        await foreach (var item in _mediator.CreateStream(new GetProductsStreamQuery(), cancellationToken))
        {
            Items.Add(item);
        }
    }
}