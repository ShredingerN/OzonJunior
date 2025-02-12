using System.Globalization;
using CsvHelper;

namespace DataAccess;

public class SalesDataRepository
{
    private readonly string _filePath;

    public SalesDataRepository(string filePath)
    {
        _filePath = filePath;
    }
    public List<SalesData> LoadData()
    {
        var reader = new StreamReader(_filePath);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<SalesData>().ToList();
    }
}