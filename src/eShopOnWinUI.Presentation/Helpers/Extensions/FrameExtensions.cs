using System.Reflection;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Helpers.Extensions;

public static class FrameExtensions
{
    public static object? GetPageViewModel(this Frame frame)
    {
        var content = frame.Content;
        var contentType = content?.GetType();
        var viewModelProperty = contentType?.GetProperty("ViewModel", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var viewModel = viewModelProperty?.GetValue(content);

        return viewModel;
    }
}