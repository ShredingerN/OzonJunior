using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
string filePath = Path.Combine(baseDirectory, "SalesData.csv");

// string filePath = "SalesData.csv";

if (!File.Exists(filePath))
{
    SalesDataGenerator.GenerateCsv(filePath);
}

ISalesDataRepository _repository = new SalesDataRepository(filePath);
ISalesCalculator _calculator = new SalesCalculator(_repository);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/product/{id}", (int id) =>
    {
        return _repository.GetProductById(id);
    })
    .WithOpenApi();

app.MapGet("/product/{id}/ads", (int id,[FromQuery]int days) =>
    {
        return _calculator.CalculateAds(days);
    })
    .WithOpenApi();

app.MapGet("/product/{id}/prediction", (int id,[FromQuery]int days) =>
    {
        return _calculator.PredictSales(id,days);
    })
    .WithOpenApi();

app.MapGet("/product/{id}/demand", (int id,[FromQuery]int days) =>
    {
        return _calculator.CalculateDemand(id,days);
    })
    .WithOpenApi();

app.Run();
