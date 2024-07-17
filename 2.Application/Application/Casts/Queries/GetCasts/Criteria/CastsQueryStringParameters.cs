using SharedKernel.Criteria.Searching;

namespace Application.Casts.Queries.GetCasts.Criteria;

/// <summary>
/// Represents a casts query string parameter
/// </summary>
public record CastsQueryStringParameters(
    string FirstName,
    string LastName,
    int? Age,
    int MaxPageSize = 50,
    int PageNumber = 1,
    int PageSize = 10,
    bool IsDeleted = false
) : QueryStringParameters(MaxPageSize, PageNumber, PageSize, IsDeleted);
