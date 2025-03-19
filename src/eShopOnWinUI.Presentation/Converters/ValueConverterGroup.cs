using Microsoft.UI.Xaml.Data;

namespace eShopOnWinUI.Presentation.Converters;

internal sealed partial class ValueConverterGroup : List<IValueConverter>, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, language));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}