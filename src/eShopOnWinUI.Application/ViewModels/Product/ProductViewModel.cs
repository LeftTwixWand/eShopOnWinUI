using CommunityToolkit.Mvvm.Messaging;
using eShopOnWinUI.Application.Features.Product;
using eShopOnWinUI.Application.Models;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.Generic;
using MediatR;

namespace eShopOnWinUI.Application.ViewModels.Product;

public sealed partial class ProductViewModel(IMediator mediator, IMessenger messenger)
    : GenericItemViewModel<ProductModel>(messenger), INavigatedTo<Guid>
{
    public async Task OnNavigatedTo(Guid productId)
    {
        var product = await mediator.Send(new GetProductByIdQuery(productId));
        Item = product ?? new ProductModel() { Name = "Product doesn't exist: Default product name" };
    }
}