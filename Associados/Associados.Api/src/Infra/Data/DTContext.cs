using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Associados.Api.src.Infra.Data
{
    public class DTContext : DbContext
    {
        private readonly string _connString = "Server=localhost;Port=5432;Username=postgres;Password=changeme;Database=DeliverIt";
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

           // modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseNpgsql(_connString,
               sqlOptions => sqlOptions.EnableRetryOnFailure(3));

            optionsBuilder.UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}