using CommunityToolkit.Mvvm.ComponentModel;

namespace eShopOnWinUI.Application.Models;

public sealed partial class ProductModel : ObservableObject
{
    [ObservableProperty]
    private Guid id;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string category = string.Empty;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private byte[]? imageSource;

    [ObservableProperty]
    private decimal price;
}