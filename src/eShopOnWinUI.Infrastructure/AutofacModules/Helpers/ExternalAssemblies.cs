using System.Reflection;
using eShopOnWinUI.Application.ViewModels.Shell;

namespace eShopOnWinUI.Infrastructure.AutofacModules.Helpers;

internal static class ExternalAssemblies
{
    public static readonly Assembly ApplicationLayer = typeof(ShellViewModel).Assembly;
}