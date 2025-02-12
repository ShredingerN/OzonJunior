using System.Globalization;
using CsvHelper;

namespace DataAccess;

public class SalesDataRepository: ISalesDataRepository
{
    private readonly string _filePath;
    
    public SalesDataRepository(string filePath)
    {
        _filePath = filePath;
    }
    public List<SalesData> LoadData()
    {
        Console.WriteLine($"Загрузка данных из файла: {_filePath}");
        var reader = new StreamReader(_filePath);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<SalesData>().ToList();

        Console.WriteLine($"Загружено записей: {records.Count}");
        return records;
    }
}