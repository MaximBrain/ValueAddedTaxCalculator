using ValueAddedTaxCalculator.Models;
using ValueAddedTaxCalculator.Services;

namespace ValueAddedTaxCalculator.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapCalculatePurchase(this WebApplication app)
    {
        app.MapPost("/calculate-purchase", (
                PurchaseInput? input,
                PurchaseCalculator purchaseCalculator,
                PurchaseValidator purchaseValidator) =>
            {
                purchaseValidator.Validate(input);
                
                var result = purchaseCalculator.Calculate(input!);
        
                return Results.Ok(result);
            })
            .WithName("CalculatePurchase")
            .WithOpenApi();

        return app;
    }
}