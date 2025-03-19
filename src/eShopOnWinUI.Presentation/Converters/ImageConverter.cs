using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;

namespace eShopOnWinUI.Presentation.Converters;

internal sealed partial class ImageConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is byte[] byteArray && byteArray.Length > 0)
        {
            using var stream = new MemoryStream(byteArray);
            var bitmapImage = new BitmapImage();
            stream.Position = 0;
            bitmapImage.SetSource(stream.AsRandomAccessStream());
            return bitmapImage;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}