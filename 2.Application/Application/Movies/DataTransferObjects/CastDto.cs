namespace Application.Movies.DataTransferObjects;

/// <summary>
/// Represents a cast dto
/// </summary>
public class CastDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }
    public int? Age { get; set; }
    public bool IsAlive { get; set; }
}
