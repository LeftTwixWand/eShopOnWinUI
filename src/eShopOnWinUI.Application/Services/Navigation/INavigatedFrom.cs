using System.Threading.Tasks;

namespace eShopOnWinUI.Application.Services.Navigation;

public interface INavigatedFrom
{
    Task OnNavigatedFrom();
}