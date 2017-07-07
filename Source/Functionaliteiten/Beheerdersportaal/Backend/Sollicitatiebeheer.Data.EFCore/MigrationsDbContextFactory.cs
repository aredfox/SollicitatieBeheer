using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Reflection;

namespace Sollicitatiebeheer.Data.EFCore
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<SollicitatiebeheerDatabase>
    {
        public SollicitatiebeheerDatabase CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
            var builder = new DbContextOptionsBuilder<SollicitatiebeheerDatabase>()
                .UseSqlServer(connectionString, cfg => {                    
                    cfg.MigrationsAssembly(typeof(SollicitatiebeheerDatabase).GetTypeInfo().Assembly.GetName().Name);
                });
            return new SollicitatiebeheerDatabase(builder.Options);
        }
    }
}
