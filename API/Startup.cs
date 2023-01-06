using DataFacade.DataSource;
using DataFacade.DataSource.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("10MinutesPublic",
                    new Microsoft.AspNetCore.Mvc.CacheProfile()
                    {
                        Duration = 10 * 60,
                        NoStore = false,
                        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any
                    });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApplicationInsightsTelemetry();

            services.AddTransient<IStoriesDataSource>((serviceProvider) => 
                new StoriesDataSource(serviceProvider.GetService<ILogger<StoriesDataSource>>()!, Configuration.GetConnectionString("CosmosDBConnection")!
            ));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://www.robertlynja.com",
                                                          "http://localhost:3000")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });

            services.AddTransient<IStoriesDataSource, StoriesDataSource>();

            services.AddOutputCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseOutputCache();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
