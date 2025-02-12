using DataAccess;


namespace BusinessLogic;

public interface ISalesCalculator
{
    double CalculateAds(List<SalesData> salesHistory, int productId);
    double PredictSales(List<SalesData> salesHistory, int productId, int days);
    double CalculateDemand(List<SalesData> salesHistory, int productId, int days);
}