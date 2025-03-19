using eShopOnWinUI.Domain.SeedWork.BusinessRules;
namespace eShopOnWinUI.Domain.Countries.Rules;

internal sealed record CountryISOMustBeInUppercase(string ISO) : IBusinessRule
{
    public string Message => "Country ISO must be in uppercase!";

    public bool BrokenWhen => ISO.Any(char.IsLower);
}