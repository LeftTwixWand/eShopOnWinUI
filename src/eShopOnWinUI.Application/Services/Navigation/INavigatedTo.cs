using System.Threading.Tasks;

namespace eShopOnWinUI.Application.Services.Navigation;

public interface INavigatedTo<T>
    where T : notnull
{
    Task OnNavigatedTo(T parameter);
}

public interface INavigatedTo : INavigatedTo<object>
{
}