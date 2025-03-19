using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Controls.CustomCommandBars;

internal sealed partial class MultipleItemsCommandBar : UserControl
{
    public static readonly DependencyProperty IsSelectionModeProperty =
        DependencyProperty.Register(nameof(IsSelectionMode), typeof(bool), typeof(MultipleItemsCommandBar), new PropertyMetadata(false));

    public static readonly DependencyProperty AddCommandProperty =
        DependencyProperty.Register(nameof(AddCommand), typeof(ICommand), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandProperty =
        DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty CreateOrderCommandProperty =
    DependencyProperty.Register(nameof(CreateOrderCommand), typeof(ICommand), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.Register(nameof(SelectedItems), typeof(object), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public MultipleItemsCommandBar()
    {
        InitializeComponent();
    }

    public bool IsSelectionMode
    {
        get => (bool)GetValue(IsSelectionModeProperty);
        set => SetValue(IsSelectionModeProperty, value);
    }

    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public ICommand CreateOrderCommand
    {
        get => (ICommand)GetValue(CreateOrderCommandProperty);
        set => SetValue(CreateOrderCommandProperty, value);
    }

    public object SelectedItems
    {
        get => GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }
}