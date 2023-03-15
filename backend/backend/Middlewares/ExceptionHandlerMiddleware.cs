using System.Net;
using System.Net.Mime;
using backend.Exceptions;
using backend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace backend.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        ContractResolver = new JsonConfiguration { NamingStrategy = new CamelCaseNamingStrategy() },
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.None,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        NullValueHandling = NullValueHandling.Ignore
    };
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }    
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var errorMessage = e switch
        {
            NotFoundException notFoundException => HandleNotFoundException(notFoundException),
            ConflictException conflictException => HandleConflictException(conflictException),
            _ => HandleUnexpectedException(e)
        };

        context.Response.StatusCode = (int)errorMessage.StatusCode;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorMessage, _jsonSerializerSettings));

    }

    private ErrorMessage HandleNotFoundException(NotFoundException e)
    {
        return new ErrorMessage(
            StatusCode: HttpStatusCode.NotFound,
            Title: "Not found",
            Details: e.Message,
            Timestamp: DateTime.Now
        );
    }

    private ErrorMessage HandleConflictException(ConflictException e)
    {
        return new ErrorMessage(
            StatusCode: HttpStatusCode.Conflict,
            Title: "Conflict",
            Details: e.Message,
            Timestamp: DateTime.Now
        );
    }
    
    private ErrorMessage HandleUnexpectedException(Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);

        return new ErrorMessage
        (
            StatusCode: HttpStatusCode.InternalServerError,
            Title: "Internal server error",
            Details: "Something went wrong :(",
            Timestamp: DateTime.UtcNow
        );
    }
}