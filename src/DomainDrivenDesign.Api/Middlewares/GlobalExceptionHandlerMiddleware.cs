using DomainDrivenDesign.Api.Dtos.Responses.Shared;

namespace DomainDrivenDesign.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (BaseException exception)
        {
            var (httpStatusCode, exceptionCode, message) = GetApiExceptionDetails(exception);

            // Write to response
            await HandleExceptionAsync(context, httpStatusCode, exceptionCode, message);
        }

        catch (Exception)
        {
            await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ExceptionCode.Default,
                "Internal Server Error");
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode httpStatusCode,
        ExceptionCode exceptionCode, string message)
    {
        if (context.Response.HasStarted)
        {
            throw new InvalidOperationException(
                "The response has already started, the http status code middleware will not be executed.");
        }

        var errorDetails = new ErrorDetails(exceptionCode);

        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true
        };
        var jsonString =
            JsonSerializer.Serialize(new ApiResponse<ErrorDetails>(errorDetails, message), serializeOptions);

        context.Response.StatusCode = (int)httpStatusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(jsonString);
    }

    private (HttpStatusCode, ExceptionCode, string) GetApiExceptionDetails(BaseException exception)
    {
        return (exception.HttpStatusCode, exception.Code, exception.Message);
    }
}
