using DataAccess;

namespace BusinessLogic;

public class SalesCalculator:ISalesCalculator
{
    private readonly ISalesDataRepository _repository;

    public SalesCalculator(ISalesDataRepository repository)
    {
        _repository = repository;
    }

    public double CalculateAds(int productId)
    {
        var filteredData = _repository.GetProductById(productId)
            .Where(d => d is { Sales: >= 0, Stock: > 0 }).ToList();

        if (!filteredData.Any())
            throw new InvalidOperationException("Нет данных для расчета ADS.");

        return filteredData.Sum(d => d.Sales) / filteredData.Count;
    }

    public double PredictSales(int productId, int days)
    {
        double ads = CalculateAds(productId);
        return ads * days;
    }

    public double CalculateDemand(int productId, int days)
    {
        double predict = PredictSales( productId, days);
        var lastStock = _repository.GetProductById(productId)
            .OrderByDescending(d => d.Date)
            .Select(d => d.Stock)
            .FirstOrDefault();
        return predict - lastStock;
    }
    
}