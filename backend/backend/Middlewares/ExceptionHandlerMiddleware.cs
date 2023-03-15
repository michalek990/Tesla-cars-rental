using System.Net;
using backend.Exceptions;
using backend.Models;

namespace backend.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
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
            ConflictException conflictException => HandleConflictException(conflictException)
        };
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
}