namespace SharedKernel.Criteria.Searching;

/// <summary>
/// Base query string parameters other custom classes will inherit from this class
/// </summary>
public abstract class QueryStringParameters
{
    /// <summary>
    /// Default max page size
    /// </summary>
    private const byte MaxPageSize = 50;

    /// <summary>
    /// Gets or sets the PageNumber
    /// </summary>
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;

    /// <summary>
    /// Gets or sets the PageSize
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    /// <summary>
    /// Gets or sets the OrderBy
    /// </summary>
    public string OrderBy { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Search
    /// </summary>
    public string Search { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the HasFilter
    /// </summary>
    protected bool HasFilter { get; set; }
}
