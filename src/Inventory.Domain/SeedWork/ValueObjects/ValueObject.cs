using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.SeedWork.ValueObjects;

public record class ValueObject
{
    /// <summary>
    /// Checks business rule for ValueObject.
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