using CommunityToolkit.Common;
using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Customers.Rules;

internal sealed record CustomerEmailMustBeValid(string Email) : IBusinessRule
{
    public string Message => "Customer email must be valid.";

    public bool BrokenWhen => StringExtensions.IsEmail(Email) is false;
}