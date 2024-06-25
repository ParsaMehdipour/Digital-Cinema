using SharedKernel.Criteria.Searching;

namespace Application.Casts.Queries.GetCasts.Criteria;

/// <summary>
/// Represents a casts query string parameter
/// </summary>
public class CastsQueryStringParameters : QueryStringParameters
{
    /// <summary>
    /// Gets or sets the FirstName
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the LastName
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Age
    /// </summary>
    public int? Age { get; set; }
}
