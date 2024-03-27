namespace ValueAddedTaxCalculator.Models;

public record PurchaseInput(decimal? NetAmount, decimal? GrossAmount, decimal? VatAmount, decimal VatRate);