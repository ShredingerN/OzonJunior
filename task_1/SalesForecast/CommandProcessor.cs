using BusinessLogic;

namespace SalesForecast;

public class CommandProcessor
{
    private readonly ISalesCalculator _calculator;

    public CommandProcessor(ISalesCalculator calculator)
    {
        _calculator = calculator;
    }

    public void Process(string command)
    {
        if (string.IsNullOrWhiteSpace(command))
        {
            Console.WriteLine("Вы ввели пустую строку, попробуйте еще раз.");
            return;
        }

        var userInput = command.Split(" ");
        int productId = 0;
        int days = 0;
        if (userInput.Length < 2 || !int.TryParse(userInput[1], out productId))
        {
            Console.WriteLine("Проверьте ввод, id продукта должен быть числом");
            return;
        }

        switch (userInput[0].ToLower())
        {
            case "ads":
                double ads = _calculator.CalculateAds(productId);
                Console.WriteLine($"Среднедневные продажи товара {productId}: {ads:F2}");
                break;
            case "prediction":
                if (userInput.Length < 3 || !int.TryParse(userInput[2], out days))
                {
                    Console.WriteLine("Не введено кол-во дней или неверный формат");
                    return;
                }
                double prediction = _calculator.PredictSales(productId, days);
                Console.WriteLine($"Прогноз продаж товара {productId} на {days} дней: {prediction:F2}");
                break;
            case "demand":
                if (userInput.Length < 3 || !int.TryParse(userInput[2], out days))
                {
                    Console.WriteLine("Не введено кол-во дней или неверный формат");
                    return;
                }
                double demand = _calculator.CalculateDemand(productId, days);
                Console.WriteLine($"Потребность в закупке товара {productId} на {days} дней: {demand:F2}");
                break;
            default:
                Console.WriteLine("Неизвестная команда.");
                break;
        }
    }
}