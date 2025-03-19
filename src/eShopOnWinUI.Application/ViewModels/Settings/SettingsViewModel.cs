using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eShopOnWinUI.Application.Services.ThemeSelector;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Application.ViewModels.Settings;

public sealed partial class SettingsViewModel : ObservableObject
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _currentTheme;

    [ObservableProperty]
    private string _versionDescription;

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _currentTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();
    }

    private static string GetVersionDescription()
    {
        var version = new Version(0, 1, 890, 3);

        /* if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;
            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }*/

        return $"AppDisplayName - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }

    [RelayCommand]
    private void SwitchTheme(ElementTheme theme)
    {
        if (CurrentTheme != theme)
        {
            CurrentTheme = theme;
            _themeSelectorService.SetTheme(theme);
        }
    }
}