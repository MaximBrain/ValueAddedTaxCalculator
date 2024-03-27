using ValueAddedTaxCalculator.Models;

namespace ValueAddedTaxCalculator.Services;

public record PurchaseCalculator
{
    public PurchaseOutput Calculate(PurchaseInput input)
    {
        if (input.NetAmount > 0)
        {
            var grossAmount = input.NetAmount * (1 + input.VatRate / 100);
            var vatAmount = grossAmount - input.NetAmount;
            return new PurchaseOutput(input.NetAmount, grossAmount, vatAmount);
        }

        if (input.GrossAmount > 0)
        {
            var netAmount = input.GrossAmount - input.GrossAmount * input.VatRate / (100 + input.VatRate);
            var vatAmount = input.GrossAmount - netAmount;
            return new PurchaseOutput(netAmount, input.GrossAmount, vatAmount);
            
        }

        // Calculate using VAT Amount
        var vatNetAmount = input.VatAmount * 100 / input.VatRate;
        var varGrossAmount = vatNetAmount + input.VatAmount;
        return new PurchaseOutput(
            vatNetAmount,
            varGrossAmount,
            input.VatAmount);
    }
}