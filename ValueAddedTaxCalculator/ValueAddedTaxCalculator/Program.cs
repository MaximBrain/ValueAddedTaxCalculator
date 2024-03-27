using ValueAddedTaxCalculator;
using ValueAddedTaxCalculator.Extensions;
using ValueAddedTaxCalculator.Middlewares;
using ValueAddedTaxCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PurchaseCalculator>();
builder.Services.AddScoped<PurchaseValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middleware to handle exceptions
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapCalculatePurchase();

app.UseHttpsRedirection();

app.Run();