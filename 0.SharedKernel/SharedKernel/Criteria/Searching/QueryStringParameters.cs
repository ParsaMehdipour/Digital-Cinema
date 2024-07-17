namespace SharedKernel.Criteria.Searching;

/// <summary>
/// Base query string parameters other custom classes will inherit from this class
/// </summary>
public record QueryStringParameters(int MaxPageSize = 50, int PageNumber = 1, int PageSize = 10, bool IsDeleted = false)
{
    private int _pageSize = PageSize;

    /// <summary>
    /// Gets or sets the PageSize
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
};