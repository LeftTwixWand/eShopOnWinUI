namespace Inventory.Domain.SeedWork.Events;

/// <summary>
/// Domain event abstraction, that stores information, when the event was occurred on.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Date and time, when the event was raised.
    /// </summary>
    DateTimeOffset OccurredOn { get; }
}