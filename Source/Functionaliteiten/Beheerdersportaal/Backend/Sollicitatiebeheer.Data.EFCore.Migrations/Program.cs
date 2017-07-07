using Microsoft.EntityFrameworkCore;
using System;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
                return;

            var program = new Program();

            switch (args[0].Trim().ToLower())
            {
                case "drop":
                    program.DropDatabase();
                    break;

                case "seed":
                    program.DropDatabase();
                    break;                
            }                
        }

        private void DropDatabase()
        {
            Console.WriteLine("Trying to delete database...");
            try
            {
                using (var db = MaakDatabase()) {
                    db.Database.EnsureDeleted();
                }
                Console.WriteLine("Database deleted.");
            } catch(Exception ex)
            {
                Console.WriteLine($"Failed to delete database: '{ex.Message}'");
                Console.WriteLine(ex.ToString());
            }            
        }

        private void SeedDatabase()
        {
            Console.WriteLine("Trying to seed database...");
            try
            {
                using (var db = MaakDatabase())
                {
                    // Todo
                }
                Console.WriteLine("Database seeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to seed database: '{ex.Message}'.");
                Console.WriteLine(ex.ToString());
            }
        }

        private static SollicitatiebeheerDatabase MaakDatabase()
        {
            var migrationsDbContextFactory = new MigrationsDbContextFactory();
            return migrationsDbContextFactory.CreateDbContext(null);
        }
    }
}
