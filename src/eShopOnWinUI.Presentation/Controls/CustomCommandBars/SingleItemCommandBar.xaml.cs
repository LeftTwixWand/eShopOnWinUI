using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Controls.CustomCommandBars;

internal sealed partial class SingleItemCommandBar : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(SingleItemCommandBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IsEditModeProperty =
        DependencyProperty.Register(nameof(IsEditMode), typeof(bool), typeof(SingleItemCommandBar), new PropertyMetadata(false));

    public static readonly DependencyProperty EditCommandProperty =
        DependencyProperty.Register(nameof(EditCommand), typeof(ICommand), typeof(SingleItemCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty CancelCommandProperty =
        DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(SingleItemCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty SaveCommandProperty =
        DependencyProperty.Register(nameof(SaveCommand), typeof(ICommand), typeof(SingleItemCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandProperty =
        DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(SingleItemCommandBar), new PropertyMetadata(null));

    public SingleItemCommandBar()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool IsEditMode
    {
        get => (bool)GetValue(IsEditModeProperty);
        set => SetValue(IsEditModeProperty, value);
    }

    public ICommand EditCommand
    {
        get => (ICommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }

    public ICommand CancelCommand
    {
        get => (ICommand)GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }

    public ICommand SaveCommand
    {
        get => (ICommand)GetValue(SaveCommandProperty);
        set => SetValue(SaveCommandProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
}