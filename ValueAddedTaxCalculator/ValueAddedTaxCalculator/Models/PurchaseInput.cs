namespace ValueAddedTaxCalculator.Models;

public record PurchaseInput
{
    public decimal? NetAmount { get; init; }
    public decimal? GrossAmount { get; init; }
    public decimal? VatAmount { get; init; }
    public decimal VatRate { get; init; }
}