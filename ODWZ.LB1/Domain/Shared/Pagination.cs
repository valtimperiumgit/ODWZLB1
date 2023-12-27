namespace ODWZ.LB1.Domain.Shared;

public class Pagination
{
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    
    private int _pageSize = 10;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public string OrderBy { get; set; } = "Name";
    public bool Ascending { get; set; } = true;
}