using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            //try
            //{
            //    var context = services.GetRequiredService<DataFacade.BlogContext>();
            //    context.Database.Migrate();
            //}
            //catch (Exception ex)
            //{
            //    var logger = services.GetRequiredService<ILogger<Program>>();
            //
            //    logger.LogError(ex, "An error occurred during DB migration");
            //}

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}