using eShopOnWinUI.Domain.Countries.Rules;
using eShopOnWinUI.Domain.SeedWork.Enumerations;

namespace eShopOnWinUI.Domain.Countries;

public sealed record Country(string Name, string ISO) : Enumeration<Country>
{
    public static Country Ukraine => Create(nameof(Ukraine), "UA");

    public static Country Poland => Create(nameof(Poland), "PL");

    public static Country UnitedStates => Create(nameof(UnitedStates), "US");

    public static Country Canada => Create(nameof(Canada), "CA");

    public static Country Mexico => Create(nameof(Mexico), "MX");

    public static Country Germany => Create(nameof(Germany), "DE");

    public static Country France => Create(nameof(France), "FR");

    public static Country Italy => Create(nameof(Italy), "IT");

    public static Country Spain => Create(nameof(Spain), "ES");

    public static Country Portugal => Create(nameof(Portugal), "PT");

    public static Country Greece => Create(nameof(Greece), "GR");

    public static Country Turkey => Create(nameof(Turkey), "TR");

    public static Country China => Create(nameof(China), "CN");

    public static Country Japan => Create(nameof(Japan), "JP");

    public static Country SouthKorea => Create(nameof(SouthKorea), "KR");

    public static Country Australia => Create(nameof(Australia), "AU");

    public static Country NewZealand => Create(nameof(NewZealand), "NZ");

    public static Country SouthAfrica => Create(nameof(SouthAfrica), "ZA");

    public static Country Argentina => Create(nameof(Argentina), "AR");

    public static Country Brazil => Create(nameof(Brazil), "BR");

    public static Country Chile => Create(nameof(Chile), "CL");

    public static Country Colombia => Create(nameof(Colombia), "CO");

    public static Country Peru => Create(nameof(Peru), "PE");

    public static Country Venezuela => Create(nameof(Venezuela), "VE");

    public static Country Egypt => Create(nameof(Egypt), "EG");

    public static Country India => Create(nameof(India), "IN");

    public static Country Indonesia => Create(nameof(Indonesia), "ID");

    public static Country Malaysia => Create(nameof(Malaysia), "MY");

    public static Country Philippines => Create(nameof(Philippines), "PH");

    public static Country Thailand => Create(nameof(Thailand), "TH");

    public static Country Vietnam => Create(nameof(Vietnam), "VN");

    public static Country SaudiArabia => Create(nameof(SaudiArabia), "SA");

    public static Country UnitedArabEmirates => Create(nameof(UnitedArabEmirates), "AE");

    public static Country UnitedKingdom => Create(nameof(UnitedKingdom), "GB");

    public static Country Create(string name, string iso)
    {
        CheckRule(new CountryNameMustNotBeEmpty(name));
        CheckRule(new CountryISOMustNotBeEmpty(iso));
        CheckRule(new CountryISOMustHaveTwoSigns(iso));
        CheckRule(new CountryISOMustContainsOnlyLetters(iso));
        CheckRule(new CountryISOMustBeInUppercase(iso));

        return new(name, iso);
    }
}