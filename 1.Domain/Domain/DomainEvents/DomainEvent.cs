using Domain.Enums;
using Domain.Primitives;
using SharedKernel.DataProviderSettings.MongoDB;
using System.ComponentModel.DataAnnotations;

namespace Domain.DomainEvents;

[BsonCollection("DomainEvents")]
public class DomainEvent : MongoEntity
{
    #region Fields

    [Required(ErrorMessage = "Table name is required")]
    public string TableName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Table record id is required")]
    public string TableRecordId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data is required")]
    public string Data { get; set; } = string.Empty;

    [Required(ErrorMessage = "State is required")]
    public DomainEventState State { get; set; }

    public Guid UserId { get; set; } = Guid.Empty;

    #endregion

    #region Ctor

    public DomainEvent() { }

    #endregion
}

