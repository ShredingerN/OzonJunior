namespace DataAccess;

public interface ISalesDataRepository
{
    List<SalesData> GetProductById(int productId);
}