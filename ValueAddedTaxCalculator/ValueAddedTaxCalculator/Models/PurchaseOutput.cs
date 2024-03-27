namespace ValueAddedTaxCalculator.Models;

public record PurchaseOutput(decimal? NetAmount, decimal? GrossAmount, decimal? VatAmount);