using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sat.Recruitment.Core;
using Sat.Recruitment.Infrastructure;
using Sat.Recruitment.Infrastructure.Data;
using Serilog;
using System;
using System.IO;
using static Sat.Recruitment.Core.PostInjection;

namespace Sat.Recruitment.Api
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            try
            {
                Log.Information("Starting web application");

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                builder.Services
                    .AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sat.Recruitment.Api", Version = "v1" });
                });

                builder.Services.AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseSqlite(
                        builder.Configuration.GetConnectionString("SqliteConnection")
                    );
                });

                builder.Services.AddHttpContextAccessor();
                builder.Services.AddHttpClient();

                builder.Services.AddInfrastructure();
                builder.Services.AddCore(builder.Configuration);

                Injector.GenerateProvider(builder.Services);

                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
                });

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseCors();
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                    app.UseSwaggerUI();
                    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sat.Recruitment.Api V1"));
                }
                else
                {
                    app.UseHsts();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

                //app.MapControllers();

                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<AppDbContext>();
                        context.Database.EnsureCreated();
                        SeedData.Initialize(services);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
                    }
                }

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
