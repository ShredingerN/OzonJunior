﻿using BusinessLogic;
using DataAccess;
using SalesForecast;

string filePath = "SalesData.csv";

if (!File.Exists(filePath))
{
    SalesDataGenerator.GenerateCsv(filePath);
}

ISalesDataRepository repository = new SalesDataRepository(filePath);
ISalesCalculator calculator = new SalesCalculator(repository);
CommandProcessor commandProcessor = new CommandProcessor(calculator);

Console.WriteLine($"Ведите одну из следующих команд:{Environment.NewLine}" +
                  $"ads id товара{Environment.NewLine}" +
                  $"prediction id товара количество дней {Environment.NewLine}" +
                  $"demand id товара количество дней{Environment.NewLine}" +
                  $"Пример ввода: prediction 10 15{Environment.NewLine}" +
                  $"Для выхода из программы введите exit");

while (true)
{
    string input = Console.ReadLine();
    if (input.Trim().ToLower().Equals("exit")) 
        break;
    commandProcessor.Process(input);
}