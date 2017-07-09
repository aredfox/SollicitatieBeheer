using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Reflection;

namespace Sollicitatiebeheer.Data.EFCore
{
    public class DefaultDbContextFactory : IDesignTimeDbContextFactory<SollicitatiebeheerDatabase>
    {
        public SollicitatiebeheerDatabase CreateDbContext(string[] args)
        {
            var options = CreateDefaultOptions();
            return new SollicitatiebeheerDatabase(options);
        }

        public string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");            
            return connectionString;
        }

        public DbContextOptions<SollicitatiebeheerDatabase> CreateDefaultOptions()
        {
            var connectionString = GetConnectionString();
            var builder = new DbContextOptionsBuilder<SollicitatiebeheerDatabase>()
                .UseSqlServer(connectionString, cfg => {
                    cfg.MigrationsAssembly(typeof(SollicitatiebeheerDatabase).GetTypeInfo().Assembly.GetName().Name);
                });
            return builder.Options;
        }
    }
}
