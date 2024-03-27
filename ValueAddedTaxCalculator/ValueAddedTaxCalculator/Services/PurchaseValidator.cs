using ValueAddedTaxCalculator.Extensions;
using ValueAddedTaxCalculator.Models;

namespace ValueAddedTaxCalculator.Services;

public record PurchaseValidator
{
    public void Validate(PurchaseInput? input)
    {
        if (input is null)
        {
            throw new BadInputException("Input is null.");
        }

        if (input.NetAmount is null or 0 && 
            input.GrossAmount is null or 0 && 
            input.VatAmount is null or 0)
        {
            throw new BadInputException("At least one of the input amounts (Net, Gross, VAT) must be provided.");
        }
                
        if (input.NetAmount is < 0 || 
            input.GrossAmount is < 0 || 
            input.VatAmount is < 0)
        {
            throw new BadInputException("Negative values are invalid.");
        }
                
        if (input is
            {NetAmount: > 0, GrossAmount: > 0}
            or {NetAmount: > 0, VatAmount: > 0}
            or {VatAmount: > 0, GrossAmount: > 0})
        {
            throw new BadInputException("Only one of the input amounts (Net, Gross, VAT) should be provided.");
        }

        if (input.VatRate is 0 or < 0 or > 100)
        {
            throw new BadInputException("Invalid VAT rate provided.");
        }
    }
}