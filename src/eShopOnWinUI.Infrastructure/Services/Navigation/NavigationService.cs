using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinUI.Animations;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Presentation.Helpers.Extensions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace eShopOnWinUI.Infrastructure.Services.Navigation;

// For more information on navigation between pages see
// https://github.com/microsoft/TemplateStudio/blob/main/docs/WinUI/navigation.md
public class NavigationService(IPageService pageService, Window window) : INavigationService
{
    private object _lastParameterUsed = string.Empty;
    private Frame? _frame;

    public event NavigatedEventHandler? Navigated;

    public Frame? Frame
    {
        get
        {
            if (_frame is null)
            {
                _frame = window.Content as Frame;
                RegisterFrameEvents();
            }

            return _frame;
        }

        set
        {
            UnregisterFrameEvents();
            _frame = value;
            RegisterFrameEvents();
        }
    }

    public bool CanGoBack => Frame is not null && Frame.CanGoBack;

    public bool GoBack()
    {
        if (CanGoBack)
        {
            object? vmBeforeNavigation = _frame?.GetPageViewModel();
            _frame?.GoBack();
            if (vmBeforeNavigation is INavigatedFrom navigatedFrom)
            {
                navigatedFrom.OnNavigatedFrom();
            }

            return true;
        }

        return false;
    }

    public void Navigate<TViewModel>(object? parameter = null, bool clearNavigation = false)
        where TViewModel : ObservableObject
    {
        _ = NavigateTo(typeof(TViewModel).FullName!, parameter, clearNavigation);
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false)
    {
        Type pageType = pageService.GetPageType(pageKey);

        if (_frame is not null && (_frame.Content?.GetType() != pageType ||
            (parameter is not null && !parameter.Equals(_lastParameterUsed))))
        {
            _frame.Tag = clearNavigation;
            object? vmBeforeNavigation = _frame.GetPageViewModel();
            bool navigated = _frame.Navigate(pageType, parameter); // Error here usually means, that the page has no default donstructor.
            if (navigated)
            {
                _lastParameterUsed = parameter;
                if (vmBeforeNavigation is INavigatedFrom navigatedFrom)
                {
                    navigatedFrom.OnNavigatedFrom();
                }
            }

            return navigated;
        }

        return false;
    }

    public void SetListDataItemForNextConnectedAnimation(object item)
    {
        Frame.SetListDataItemForNextConnectedAnimation(item);
    }

    private void RegisterFrameEvents()
    {
        if (_frame is not null)
        {
            _frame.Navigated += OnNavigated;
        }
    }

    private void UnregisterFrameEvents()
    {
        if (_frame is not null)
        {
            _frame.Navigated -= OnNavigated;
        }
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame)
        {
            TryClearNavigationHistory(frame.Tag);

            // TODO: Use lastParameterUsed to prevent navigation to the same page with the same arguments
            AddNavigarionParameter(e.Parameter);

            Navigated?.Invoke(sender, e);
        }
    }

    private void TryClearNavigationHistory(object tag)
    {
        bool clearNavigation = (bool)tag;
        if (clearNavigation)
        {
            _frame?.BackStack.Clear();
        }
    }

    private void AddNavigarionParameter(object navigationParameter)
    {
        object? viewModel = _frame?.GetPageViewModel();

        if (viewModel is null)
        {
            return;
        }

        IEnumerable<Type> navigationInterfaces = viewModel
            .GetType()
            .GetInterfaces()
            .Where(implementedInterface => implementedInterface.IsGenericType
            && implementedInterface.GetGenericTypeDefinition() == typeof(INavigatedTo<>));

        if (!navigationInterfaces.Any())
        {
            return;
        }

        _lastParameterUsed = navigationParameter;

        // TODO: Throw an error, if navigation has failed
        _ = navigationInterfaces.Any(i => HandleNavigation(i, viewModel));
    }

    private bool HandleNavigation(Type navigationInterface, object viewModel)
    {
        Type[] genericParameters = navigationInterface.GetGenericArguments();
        Type? parameterType = genericParameters.FirstOrDefault(genericParameterType => genericParameterType == _lastParameterUsed?.GetType());

        if (parameterType is null)
        {
            // ThrowHelper.ThrowInvalidOperationException(
            //    $"Parameter, that you're passing into {nameof(INavigationService)}.{nameof(INavigationService.NavigateTo)} has type: ({_lastParameterUsed.GetType()}) " +
            //    $"but {viewModel.GetType().Name} implements generic interface of type {nameof(INavigatedTo)}<{genericParameters.First()}>." +
            //    $"Make sure, that you're passing a correct parameter to the {nameof(INavigationService)}.{nameof(INavigationService.NavigateTo)} method. " +
            //    $"Also, make sure, that {viewModel.GetType().Name} expects correct type in {nameof(INavigatedTo)} interface.");

            return false;
        }

        object value = Convert.ChangeType(_lastParameterUsed, parameterType);

        MethodInfo? onNavigatedToMethod = navigationInterface.GetMethod(nameof(INavigatedTo.OnNavigatedTo));
        _ = onNavigatedToMethod?.Invoke(viewModel, new object[] { value });

        return true;
    }
}