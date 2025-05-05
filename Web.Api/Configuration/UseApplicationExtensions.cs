using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.Api.Configuration
{
    public static class UseApplicationExtensions
    {
        public static WebApplication Configure(this WebApplication app) 
        {
            app.UseConfiguredSwagger();
            app.UseHttpsRedirection();
            app.ConfigureExceptionHandler();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("AllowFrontend");

            return app;
        }

        private static WebApplication UseConfiguredSwagger(this WebApplication app) 
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }

        private static WebApplication ConfigureExceptionHandler(this WebApplication app) 
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (exception is ValidationException validationException)
                    {
                        // Zwracamy 400 Bad Request w przypadku błędu walidacji
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/json";

                        var errors = validationException.Message;
                        await context.Response.WriteAsJsonAsync(new { error = errors });
                    }
                    //else if (exception is ApplicationException applicationException) 
                    //{
                    //    context.Response.StatusCode = StatusCodes.Status204NoContent;
                    //    context.Response.ContentType = "application/json";
                    //    await context.Response.WriteAsJsonAsync(applicationException.Message);
                    //}
                    else if (exception is KeyNotFoundException keyNotFoundException)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(keyNotFoundException.Message);
                    }
                    else
                    {
                        // Dla wszystkich innych wyjątków zwracamy 500 Internal Server Error
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred" });
                    }
                });
            });

            return app;
        }

    }
}
