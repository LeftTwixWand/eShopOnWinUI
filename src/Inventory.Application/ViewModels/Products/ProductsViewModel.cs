using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Features.Products.DeleteProducts;
using Inventory.Application.Features.Products.GetProducts;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.Generic;
using Inventory.Application.ViewModels.Product;
using MediatR;

namespace Inventory.Application.ViewModels.Products;

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

    protected override void ItemClicked(ProductModel clickedItem)
    {
        _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
        _navigationService.Navigate<ProductViewModel>(clickedItem.Id);
    }

    protected override void CreateNewItem()
    {
        _navigationService.Navigate<ProductViewModel>();
    }

    protected override async Task DeleteItems(IList<object> selectedItems, CancellationToken cancellationToken)
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