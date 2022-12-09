namespace IvanRealEstate.Extensions
{
    using Microsoft.AspNetCore.Diagnostics;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.ErrorModel;
    using IvanRealEstate.Entities.Exceptions;

    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHendler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
