namespace PCAtranka.Core.Requests.Person;
public class PersonParameters
{
    const int maxPageSize = 50;
    
    public string? IdFilter { get; set; }
    public string? NameFilter { get; set; }
    public string? AgeFilter { get; set; }
    public string? HeightFilter { get; set; }
    public string? SortingField { get; set; }
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
    }
}