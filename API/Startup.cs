using API.Models;

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
            services.AddSwaggerGen(options =>
            {
                options.SupportNonNullableReferenceTypes();
            });

            services.AddApplicationInsightsTelemetry();

            services.AddTransient<DataFacade.DataSource.Interfaces.IStoriesDataSource, DataFacade.DataSource.StoriesDataSource>();
            services.AddSingleton<DataFacade.DB.CosmosDB>((serviceProvider) => new DataFacade.DB.CosmosDB(serviceProvider.GetService<ILogger<DataFacade.DB.CosmosDB>>()!, Configuration.GetConnectionString("CosmosConnection")!));

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

            services.AddOutputCache();
            services.AddAutoMapper(typeof(StoriesProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging() || env.IsEnvironment("Local"))
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
