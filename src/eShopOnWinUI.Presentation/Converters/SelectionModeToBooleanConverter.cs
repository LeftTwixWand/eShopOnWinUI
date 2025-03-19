using CommunityToolkit.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace eShopOnWinUI.Presentation.Converters;

internal sealed partial class SelectionModeToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool isSelectionMode)
        {
            return isSelectionMode ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None;
        }

        ThrowHelper.ThrowArgumentException(nameof(value), $"Value has to be of type {typeof(bool)}");
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}