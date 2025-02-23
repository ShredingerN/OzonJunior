namespace BusinessLogic;

public interface ISalesCalculator
{
    double CalculateAds(int productId);
    double PredictSales(int productId, int days);
    double CalculateDemand(int productId, int days);
}