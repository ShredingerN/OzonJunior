using System.Globalization;
using Bogus;


namespace DataAccess;

public class SalesDataGenerator
{
    private const int ProductCount = 10;
    private const int Days = 30;
    private const int MinSales = 0;
    private const int MaxSales = 20;
    private const int MinStock = 0;
    private const int MaxStock = 100;

    public static void GenerateCsv(string filePath)
    {
        var startDate = DateTime.Today.AddDays(-Days);
        var dates = Enumerable.Range(0, Days).Select(i => startDate.AddDays(i)).ToList();

        var products = Enumerable.Range(1, ProductCount).ToList();
        var salesDataList = new List<SalesData>();

        var faker = new Faker();

        foreach (var productId in products)
        {
            foreach (var date in dates)
            {
                var salesData = new SalesData
                {
                    Id = productId,
                    Date = date,
                    Sales = faker.Random.Int(MinSales, MaxSales),
                    Stock = faker.Random.Int(MinStock, MaxStock)
                };
                salesDataList.Add(salesData);
            }
        }

        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Id,Date,Sales,Stock");
            foreach (var salesData in salesDataList)
            {
                writer.WriteLine($"{salesData.Id}, " +
                                 $"{salesData.Date.ToString("dd-MM-yyyy",CultureInfo.InvariantCulture)}, " +
                                 $"{salesData.Sales}, " +
                                 $"{salesData.Stock}");
            }
        }
    }
}