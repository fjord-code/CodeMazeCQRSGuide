using CodeMazeCQRSGuide.Constants;
using Entities.ErrorModel;
using Entities.Exceptions;
using Entities.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace CodeMazeCQRSGuide.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILogger<Exception> logger)
    {
        app.UseExceptionHandler(applicationBuilder =>
        {
            applicationBuilder.Run(async context =>
            {
                context.Response.ContentType = ContentTypeConstants.ApplicationJson;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        ValidationAppException => StatusCodes.Status422UnprocessableEntity,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LogError($"Something went wrong: {contextFeature.Error}.");

                    if (contextFeature.Error is ValidationAppException exception)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new { exception.Errors }));
                    }
                    else
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                }
            });
        });
    }
}
