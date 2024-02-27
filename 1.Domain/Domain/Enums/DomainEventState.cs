namespace Domain.Enums;

/// <summary>
/// Statuses related to a domain event
/// </summary>
public enum DomainEventState
{
    Created = 1,
    Updated = 2,
    Deleted = 3,
    Restored = 4
}
