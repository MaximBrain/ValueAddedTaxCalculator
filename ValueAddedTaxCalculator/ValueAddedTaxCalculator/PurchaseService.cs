using ValueAddedTaxCalculator.Models;

namespace ValueAddedTaxCalculator;

public record PurchaseService
{
    public PurchaseOutput CalculatePurchase(PurchaseInput input)
    {
        if (input.NetAmount == null)
        {
            // Calculate Net Amount
            var netAmount = (decimal)input.GrossAmount! - ((decimal)input.GrossAmount * input.VatRate / (100 + input.VatRate));
            return new PurchaseOutput(netAmount, input.GrossAmount, input.VatAmount);
        }

        if (input.GrossAmount == null)
        {
            // Calculate Gross Amount
            var grossAmount = (decimal)input.NetAmount * (1 + input.VatRate / 100);
            return new PurchaseOutput(input.NetAmount, grossAmount, input.VatAmount);
        }

        // Calculate VAT Amount
        var vatAmount = (decimal)input.GrossAmount - (decimal)input.NetAmount;
        return new PurchaseOutput(input.NetAmount, input.GrossAmount, vatAmount);
    }
}