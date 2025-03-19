using System;

namespace eShopOnWinUI.Application.Services.Navigation;

public interface IPageService
{
    Type GetPageType(string key);
}