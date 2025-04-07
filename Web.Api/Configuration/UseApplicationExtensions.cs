namespace Web.Api.Configuration
{
    public static class UseApplicationExtensions
    {
        public static WebApplication Configure(this WebApplication app) 
        {
            app.UseConfiguredSwagger();
            app.UseHttpsRedirection();
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
    }
}
