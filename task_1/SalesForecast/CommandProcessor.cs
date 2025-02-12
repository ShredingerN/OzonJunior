using BusinessLogic;
using DataAccess;

namespace SalesForecast;

public class CommandProcessor
{
    private readonly ISalesDataRepository _repository;
    private readonly ISalesCalculator _calculator;

    public CommandProcessor(ISalesCalculator calculator, ISalesDataRepository repository)
    {
        _calculator = calculator;
        _repository = repository;
    }

    public void Process(string command)
    {
        if (string.IsNullOrWhiteSpace(command))
        {
            Console.WriteLine("Вы ввели пустую строку, попробуйте еще раз.");
        }

        var userInput = command.Split(" ");
        int productId = int.Parse(userInput[1]);
        int days = int.Parse(userInput[2]);
        
        if (userInput.Length < 2 || !int.TryParse(userInput[1], out productId))
        {
            Console.WriteLine("Неизвестная команда");
        }
        
        var salesData = _repository.LoadData();

        switch (userInput[0].ToLower())
        {
            case "ads":
                double ads = _calculator.CalculateAds(salesData, productId);
                Console.WriteLine($"Среднедневные продажи товара {productId}: {ads:F2}");
                break;
            case "prediction":
                if (userInput.Length < 3 || !int.TryParse(userInput[2],out days))
                {
                    Console.WriteLine("Укажите количество дней.");
                }

                double prediction = _calculator.PredictSales(salesData, productId, days);
                Console.WriteLine($"Прогноз продаж товара {productId} на {days} дней: {prediction:F2}");
                break;

            case "demand":
                if (userInput.Length < 3 || !int.TryParse(userInput[2], out days))
                {
                    Console.WriteLine("Укажите количество дней.");
                }
                double demand = _calculator.CalculateDemand(salesData, productId, days);
                Console.WriteLine($"Потребность в закупке товара {productId} на {days} дней: {demand:F2}");
                break;
            default:
                Console.WriteLine("Неизвестная команда.");
                break;
        }
    }
}