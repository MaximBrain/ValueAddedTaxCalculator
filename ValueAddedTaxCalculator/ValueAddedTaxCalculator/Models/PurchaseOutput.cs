using System.Net;

namespace ValueAddedTaxCalculator.Models;

public record PurchaseOutput(decimal? NetAmount, decimal? GrossAmount, decimal? VatAmount);

public record ExceptionResponse(HttpStatusCode StatusCode, string Description);