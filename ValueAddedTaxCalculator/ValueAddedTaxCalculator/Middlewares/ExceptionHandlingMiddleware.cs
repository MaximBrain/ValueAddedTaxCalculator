using System.Net;
using ValueAddedTaxCalculator.Extensions;
using ValueAddedTaxCalculator.Models;

namespace ValueAddedTaxCalculator.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "An unexpected error occurred.");

        var response = exception switch
        {
            BadInputException x => new ExceptionResponse(HttpStatusCode.BadRequest, x.Message),
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}