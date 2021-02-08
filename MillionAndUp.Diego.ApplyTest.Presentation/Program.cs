namespace MillionAndUp.Diego.ApplyTest.Presentation
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.Services;

    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            RunMigrationDatabase(host);
            host.Run();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }

        /// <summary>
        /// Runs the migration database.
        /// </summary>
        /// <param name="host">The host.</param>
        private static void RunMigrationDatabase(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var seeder = scope.ServiceProvider.GetService<DatabaseHelperService>();
            seeder.ApplyMigrationsAsync().Wait();
        }
    }
}
