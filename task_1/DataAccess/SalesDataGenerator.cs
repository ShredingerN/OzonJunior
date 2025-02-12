using System.Globalization;
using Bogus;
using CsvHelper;


namespace DataAccess;

public class SalesDataGenerator
{
    private const int ProductCount = 30;
    private const int Days = 30;
    private const int MinSales = 0;
    private const int MaxSales = 20;
    private const int MinStock = 0;
    private const int MaxStock = 100;

    public static void GenerateCsv(string filePath)
    {
        var startDate = DateTime.Today.AddDays(-Days);

        var products = Enumerable.Range(1, ProductCount).ToList();
        var faker = new Faker<SalesData>()
            .RuleFor(s => s.Id, f => f.PickRandom(products))
            .RuleFor(s => s.Date, f => startDate.AddDays(f.IndexGlobal))
            .RuleFor(s => s.Sales, f => f.Random.Int(MinSales, MaxSales))
            .RuleFor(s => s.Stock, f => f.Random.Int(MinStock, MaxStock));

        var salesData = faker
            .Generate(Days * ProductCount)
            .OrderBy(s => s.Id)
            .ThenBy(s => s.Date).ToList();
        var writer = new StreamWriter(filePath);
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(salesData);
    }
}