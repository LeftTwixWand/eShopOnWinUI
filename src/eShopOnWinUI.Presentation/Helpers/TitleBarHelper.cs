using System.Runtime.InteropServices;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace eShopOnWinUI.Presentation.Helpers;

// Helper class to workaround custom title bar bugs.
// DISCLAIMER: The resource key names and color values used below are subject to change. Do not depend on them.
// https://github.com/microsoft/TemplateStudio/issues/4516
public sealed class TitleBarHelper
{
    private const int WAINACTIVE = 0x00;
    private const int WAACTIVE = 0x01;
    private const int WMACTIVATE = 0x0006;

    public static void UpdateTitleBar(ElementTheme theme, Window window)
    {
        if (window.ExtendsContentIntoTitleBar)
        {
            if (theme != ElementTheme.Default)
            {
                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionForeground"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
                    _ => new SolidColorBrush(Colors.Transparent)
                };

                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionForegroundDisabled"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Color.FromArgb(0x66, 0xFF, 0xFF, 0xFF)),
                    ElementTheme.Light => new SolidColorBrush(Color.FromArgb(0x66, 0x00, 0x00, 0x00)),
                    _ => new SolidColorBrush(Colors.Transparent)
                };

                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionButtonBackgroundPointerOver"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Color.FromArgb(0x33, 0xFF, 0xFF, 0xFF)),
                    ElementTheme.Light => new SolidColorBrush(Color.FromArgb(0x33, 0x00, 0x00, 0x00)),
                    _ => new SolidColorBrush(Colors.Transparent)
                };

                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionButtonBackgroundPressed"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Color.FromArgb(0x66, 0xFF, 0xFF, 0xFF)),
                    ElementTheme.Light => new SolidColorBrush(Color.FromArgb(0x66, 0x00, 0x00, 0x00)),
                    _ => new SolidColorBrush(Colors.Transparent)
                };

                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionButtonStrokePointerOver"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
                    _ => new SolidColorBrush(Colors.Transparent)
                };

                Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionButtonStrokePressed"] = theme switch
                {
                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
                    _ => new SolidColorBrush(Colors.Transparent)
                };
            }

            Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionBackground"] = new SolidColorBrush(Colors.Transparent);
            Microsoft.UI.Xaml.Application.Current.Resources["WindowCaptionBackgroundDisabled"] = new SolidColorBrush(Colors.Transparent);

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            if (hwnd == GetActiveWindow())
            {
                SendMessage(hwnd, WMACTIVATE, WAINACTIVE, nint.Zero);
                SendMessage(hwnd, WMACTIVATE, WAACTIVE, nint.Zero);
            }
            else
            {
                SendMessage(hwnd, WMACTIVATE, WAACTIVE, nint.Zero);
                SendMessage(hwnd, WMACTIVATE, WAINACTIVE, nint.Zero);
            }
        }
    }

    [DllImport("user32.dll")]
    private static extern nint GetActiveWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern nint SendMessage(nint hWnd, int msg, int wParam, nint lParam);
}