namespace DataAccess;

public class SalesDataRepository : ISalesDataRepository
{
    private readonly string _filePath;

    public SalesDataRepository(string filePath)
    {
        _filePath = filePath;
    }

    public List<SalesData> LoadData()
    {
        var salesData = File.ReadLines(_filePath)
            .Skip(1)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l =>
            {
                var parts = l.Split(',');
                return new SalesData
                {
                    Id = int.Parse(parts[0]),
                    Date = DateTime.Parse(parts[1]),
                    Sales = int.Parse(parts[2]),
                    Stock = int.Parse(parts[3]),
                };
            }).ToList();

        // Console.WriteLine($"Загружено записей: {salesData.Count}");
        // foreach (var record in salesData)
        // {
        //     Console.WriteLine($"Id: {record.Id}, Date: {record.Date}, Sales: {record.Sales}, Stock: {record.Stock}");
        // }

        return salesData;
    }
    
    public List<SalesData> GetProductById(int productId)
    {
        var salesData = LoadData();
        return salesData.Where(x => x.Id == productId).ToList();
    }
}