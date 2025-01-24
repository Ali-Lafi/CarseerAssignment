namespace CarseerAssignment.Infrastructure.Helpers;

public class ApiResponse<T>
{
    public int Count { get; set; }
    public string Message { get; set; }
    public string SearchCriteria { get; set; }
    public List<T> Results { get; set; }
}
