using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.Services.Navigation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactivity;

namespace eShopOnWinUI.Presentation.Behaviors;

public sealed class NavigationViewHeaderBehavior : Behavior<NavigationView>
{
    public static readonly DependencyProperty DefaultHeaderProperty =
        DependencyProperty.Register("DefaultHeader", typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => _current!.UpdateHeader()));

    public static readonly DependencyProperty HeaderModeProperty =
        DependencyProperty.RegisterAttached("HeaderMode", typeof(bool), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(NavigationViewHeaderMode.Always, (d, e) => _current!.UpdateHeader()));

    public static readonly DependencyProperty HeaderContextProperty =
        DependencyProperty.RegisterAttached("HeaderContext", typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => _current!.UpdateHeader()));

    public static readonly DependencyProperty HeaderTemplateProperty =
        DependencyProperty.RegisterAttached("HeaderTemplate", typeof(DataTemplate), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => _current!.UpdateHeaderTemplate()));

    private static NavigationViewHeaderBehavior? _current;

    private Page? _currentPage;

    public object DefaultHeader
    {
        get => GetValue(DefaultHeaderProperty);
        set => SetValue(DefaultHeaderProperty, value);
    }

    public DataTemplate? DefaultHeaderTemplate { get; set; }

    public static NavigationViewHeaderMode GetHeaderMode(Page item)
    {
        return (NavigationViewHeaderMode)item.GetValue(HeaderModeProperty);
    }

    public static void SetHeaderMode(Page item, NavigationViewHeaderMode value)
    {
        item.SetValue(HeaderModeProperty, value);
    }

    public static object GetHeaderContext(Page item)
    {
        return item.GetValue(HeaderContextProperty);
    }

    public static void SetHeaderContext(Page item, object value)
    {
        item.SetValue(HeaderContextProperty, value);
    }

    public static DataTemplate GetHeaderTemplate(Page item)
    {
        return (DataTemplate)item.GetValue(HeaderTemplateProperty);
    }

    public static void SetHeaderTemplate(Page item, DataTemplate value)
    {
        item.SetValue(HeaderTemplateProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        // TODO: Inject INavigationService automatically, not using Ioc.
        var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        navigationService.Navigated += OnNavigated;

        _current = this;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        // TODO: Inject INavigationService automatically, not using Ioc.
        var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        navigationService.Navigated -= OnNavigated;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame && frame.Content is Page page)
        {
            _currentPage = page;

            UpdateHeader();
            UpdateHeaderTemplate();
        }
    }

    private void UpdateHeader()
    {
        if (_currentPage is null)
        {
            return;
        }

        var headerMode = GetHeaderMode(_currentPage);

        if (headerMode == NavigationViewHeaderMode.Never)
        {
            AssociatedObject.Header = null;
            AssociatedObject.AlwaysShowHeader = false;
            return;
        }

        AssociatedObject.Header = GetHeaderContext(_currentPage) ?? DefaultHeader;
        AssociatedObject.AlwaysShowHeader = headerMode is NavigationViewHeaderMode.Always;
    }

    private void UpdateHeaderTemplate()
    {
        if (_currentPage is null)
        {
            return;
        }

        var headerTemplate = GetHeaderTemplate(_currentPage);
        AssociatedObject.HeaderTemplate = headerTemplate ?? DefaultHeaderTemplate;
    }
}