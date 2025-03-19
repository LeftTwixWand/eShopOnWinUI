using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.SeedWork.ValueObjects;

public record class ValueObject
{
    /// <summary>
    /// Checks business rules.
    /// </summary>
    /// <param name="rule">Business rule to check.</param>
    /// <exception cref="BusinessRuleValidationException">Exception can be thrown on invalid business rule.</exception>
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.BrokenWhen)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}