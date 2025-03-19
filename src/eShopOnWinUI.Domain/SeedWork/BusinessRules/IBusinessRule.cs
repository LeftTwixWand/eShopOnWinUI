namespace eShopOnWinUI.Domain.SeedWork.BusinessRules;

/// <summary>
/// Interface, that business rule has to implement.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Error message, that will be shown in case, when rule is broken.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Checks, if business rule is broken.
    /// </summary>
    /// <returns>True, when rule is broken.</returns>
    bool BrokenWhen { get; }
}