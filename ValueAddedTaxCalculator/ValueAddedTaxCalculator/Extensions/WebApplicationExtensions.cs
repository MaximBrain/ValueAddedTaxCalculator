using ValueAddedTaxCalculator.Models;

namespace ValueAddedTaxCalculator.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapCalculatePurchase(this WebApplication app)
    {
        app.MapPost("/calculate-purchase", (PurchaseInput? input, PurchaseService purchaseService) =>
            {
                if (input is null)
                {
                    return Results.BadRequest("Input is null.");
                }

                if (input.NetAmount == null && input.GrossAmount == null && input.VatAmount == null)
                {
                    return Results.BadRequest("At least one of the input amounts (Net, Gross, VAT) must be provided.");
                }

                if (input is {NetAmount: not null, GrossAmount: not null, VatAmount: not null})
                {
                    return Results.BadRequest("Only one of the input amounts (Net, Gross, VAT) should be provided.");
                }

                if (input.VatRate is 0 or < 0 or > 100)
                {
                    return Results.BadRequest("Invalid VAT rate provided.");
                }

                var result = purchaseService.CalculatePurchase(input);
        
                return Results.Ok(result);
            })
            .WithName("CalculatePurchase")
            .WithOpenApi();

        return app;
    }
}