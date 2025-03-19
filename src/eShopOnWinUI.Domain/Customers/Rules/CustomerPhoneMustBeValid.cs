using CommunityToolkit.Common;
using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Customers.Rules;

internal sealed record CustomerPhoneMustBeValid(string Phone) : IBusinessRule
{
    public string Message => "Customer phone number must be valid.";

    public bool BrokenWhen => StringExtensions.IsPhoneNumber(Phone) is false;
}