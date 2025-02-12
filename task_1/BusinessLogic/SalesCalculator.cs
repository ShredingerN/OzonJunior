using DataAccess;

namespace BusinessLogic;

public class SalesCalculator:ISalesCalculator
{
    public double CalculateAds(List<SalesData> salesData, int productId)
    {
        var filteredData = salesData
            .Where(d => d.Id == productId && d is { Sales: >= 0, Stock: > 0 }).ToList();

        if (!filteredData.Any())
            throw new InvalidOperationException("Нет данных для расчета ADS.");

        return filteredData.Sum(d => d.Sales) / filteredData.Count;
    }

    public double PredictSales(List<SalesData> salesData, int productId, int days)
    {
        double ads = CalculateAds(salesData, days);
        return ads * days;
    }

    public double CalculateDemand(List<SalesData> salesData, int productId, int days)
    {
        double predict = PredictSales(salesData, productId, days);
        var lastStock = salesData
            .Where(d => d.Id == productId)
            .OrderByDescending(d => d.Date)
            .Select(d => d.Stock)
            .FirstOrDefault();
        return predict - lastStock;
    }
}