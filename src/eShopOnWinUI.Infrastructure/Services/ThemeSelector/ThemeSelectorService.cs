using eShopOnWinUI.Application.Services.ThemeSelector;
using eShopOnWinUI.Presentation.Helpers;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Infrastructure.Services.ThemeSelector;

public sealed class ThemeSelectorService : IThemeSelectorService
{
    private const string SettingsKey = "AppBackgroundRequestedTheme";
    //private readonly ApplicationDataStorageHelper _applicationDataStorage = new(ApplicationData.Current);

    private readonly Window _window;

    public ThemeSelectorService(Window window)
    {
        _window = window;
    }

    public ElementTheme Theme { get; private set; } = ElementTheme.Default;

    public void Initialize()
    {
        Theme = LoadThemeFromSettings();
    }

    public void SetTheme(ElementTheme theme)
    {
        Theme = theme;

        SetRequestedTheme();
        SaveThemeInSettings(Theme);
    }

    public void SetRequestedTheme()
    {
        if (_window.Content is FrameworkElement rootElement)
        {
            rootElement.RequestedTheme = Theme;

            TitleBarHelper.UpdateTitleBar(Theme, _window);
        }
    }

    private ElementTheme LoadThemeFromSettings()
    {
        //if (_applicationDataStorage.TryRead<string>(SettingsKey, out var themeName))
        //{
        //    if (Enum.TryParse(themeName, out ElementTheme cacheTheme))
        //    {
        //        return cacheTheme;
        //    }
        //}

        return ElementTheme.Default;
    }

    private void SaveThemeInSettings(ElementTheme theme)
    {
        //_applicationDataStorage.Save(SettingsKey, theme.ToString());
    }
}