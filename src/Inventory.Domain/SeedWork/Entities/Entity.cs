using Inventory.Domain.SeedWork.BusinessRules;
using Inventory.Domain.SeedWork.Events;

namespace Inventory.Domain.SeedWork.Entities;

public abstract class Entity
{
    /// <summary>
    /// Checks business rule for Entity.
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

/// <summary>
/// Base class for entity which supports event sourcing.
/// </summary>
public abstract class Entity<TDomainEvent> : Entity
    where TDomainEvent : IDomainEvent
{
    private readonly List<TDomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets occurred domain events.
    /// </summary>
    public IReadOnlyCollection<TDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Clear list of domain events for current entity object.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Add domain event to the collection of domain events for current entity.
    /// </summary>
    /// <param name="domainEvent">Occurred domain event.</param>
    /// <exception cref="ArgumentNullException">The domain event must not be empty.</exception>
    protected void AddDomainEvent(TDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}