using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using Inventory.Application.Features.Products.GetProductById;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.Generic;
using MediatR;

namespace Inventory.Application.ViewModels.Product;

public sealed partial class ProductViewModel(IMediator mediator, IMessenger messenger)
    : GenericItemViewModel<ProductModel>(messenger),
    INavigatedTo<Guid>
{
    public async Task OnNavigatedTo(Guid productId)
    {
        var product = await mediator.Send(new GetProductByIdQuery(productId));
        Item = product ?? new ProductModel() { Name = "Product doesn't exist: Default product name" };
    }
}