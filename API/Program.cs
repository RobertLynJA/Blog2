using API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Configuration;
using System.Reflection;
using System.Security.Claims;
using MediatR;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.CacheProfiles.Add("10MinutesPublic",
                new Microsoft.AspNetCore.Mvc.CacheProfile()
                {
                    Duration = 10 * 60,
                    NoStore = false,
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any
                });
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();
        });

        builder.Services.AddApplicationInsightsTelemetry();

        builder.Services.AddTransient<DataFacade.DataSource.Interfaces.IStoriesDataSource, DataFacade.DataSource.StoriesDataSource>();
        builder.Services.AddSingleton<DataFacade.DB.CosmosDB>((serviceProvider) => new DataFacade.DB.CosmosDB(serviceProvider.GetService<ILogger<DataFacade.DB.CosmosDB>>()!, configuration.GetConnectionString("CosmosConnection")!));

        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        builder.Services.AddCors(options =>
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

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = configuration["Auth0Settings:Authority"];
            options.Audience = configuration["Auth0Settings:Audience"];

            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
                  policy.RequireAssertion(context =>
                      context.User.HasClaim(c =>
                          (c.Type == "permissions" &&
                          c.Value == "write:stories") &&
                          c.Issuer == $"{configuration["Auth0:Authority"]}")));
        }
        );

        builder.Services.AddOutputCache();
        builder.Services.AddAutoMapper(typeof(StoriesProfile));
        builder.Services.AddSingleton<RestClient>();
        builder.Services.AddMediatR(Assembly.Load(nameof(DataFacade)));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsEnvironment("Local"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseOutputCache();
        app.MapControllers();

        app.Run();
    }
}