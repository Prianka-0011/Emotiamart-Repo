using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using EmotiaMart.Application.Interfaces;
using EmotiaMart.Infrastructure.Data;
using EmotiaMart.Infrastructure.Repositories;

namespace EmotiaMart.Infrastructure
{
    public static class DependencyInjection
    {
        private static string dbHost => 
            Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true"
                ? "emotia-mart-sql"
                : "localhost";

        private static int dbPort => int.TryParse(Environment.GetEnvironmentVariable("DB_PORT"), out var port) ? port : 1433;
        private static string dbName => Environment.GetEnvironmentVariable("DB_NAME") ?? "EmotiaMartDb";
        private static string dbUser => Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
        private static string dbPass => Environment.GetEnvironmentVariable("DB_PASS") ?? "EmotiaMart123!";

        public static string GetConnectionString(string databaseName)
        {
            return $"Server={dbHost},{dbPort};Database={databaseName};User Id={dbUser};Password={dbPass};TrustServerCertificate=True;Encrypt=False;";
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine($"DB Connection String: {GetConnectionString(dbName)}");

            // Add EF Core with retry on transient failures
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    GetConnectionString(dbName),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                );
            });

            // Quartz setup
            services.AddQuartz(q =>
            {
                q.SchedulerName = "EmotiaMart-Scheduler";
                q.SchedulerId = "AUTO";

                q.UseSimpleTypeLoader();

                q.UsePersistentStore(s =>
                {
                    s.UseClustering();
                    s.UseSqlServer(c =>
                    {
                        c.ConnectionString = GetConnectionString(dbName);
                        c.TablePrefix = "EMOTIA_QRTZ_";
                    });
                    s.UseJsonSerializer();
                });

                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            // Register other services, repositories, etc.
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
