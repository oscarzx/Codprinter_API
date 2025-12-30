using Codprinter.Labels.Domain.Exceptions;
using Codprinter.Printers.Application.Exceptions;
using Codprinter.Products.Application.Exceptions;
using Codprinter.WeighingScales.Application.Exceptions;
using Codprinter.WeighingScales.Domain.Exceptions;
using Npgsql;
using System.Net;
using System.Text.Json;

namespace Codprinter.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware(
        RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            
            catch (InvalidLabelException ex)
            {
                logger.LogWarning(ex, "Invalid label exception occurred.");
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch(PrinterAlreadyExistException ex)
            {
                logger.LogWarning(ex, "Printer already exists exception occurred.");
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.Conflict);
            }
            catch (ProductAlreadyExistException)
            {
                logger.LogWarning("Product already exists exception occurred.");
                await HandleExceptionAsync(context, "El producto ya existe.", HttpStatusCode.Conflict);
            }
            catch(ProductNotFoundException ex)
            {
                logger.LogWarning(ex, "Product not found exception occurred.");
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (NpgsqlException ex)
            {
                logger.LogError(ex, "Database exception occurred.");
                await HandleExceptionAsync(context, "Error de base de datos.", HttpStatusCode.InternalServerError);
            }
            catch (InvalidWeighingScaleException)
            {
                logger.LogWarning("Invalid weighing scale exception occurred.");
                await HandleExceptionAsync(context, "Báscula de pesaje inválida.", HttpStatusCode.BadRequest);
            }
            catch(WeighingScaleAlreadyExistException ex)
            {
                logger.LogWarning(ex, "Weighing scale already exists exception occurred.");
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.Conflict);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occurred while processing the request.");
                await HandleExceptionAsync(context, "Ocurrió un error inesperado.", HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new { error = message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
