using CsvHelper.Configuration.Attributes;

namespace DataAccess;

public class SalesData
{
    public int Id { get; init; }
    [Format("dd-MM-yyyy")]
    public DateTime Date { get; init; }
    public int Sales { get; init; }
    public int Stock { get; init; }
    
}