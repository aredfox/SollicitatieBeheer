using Beheerdersportaal.Model.Gedeeld;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sollicitatiebeheer.Data.EFCore.Infrastructuur
{
    public static class DbContextExtensions
    {
        public static IEnumerable<Type> GeefAlleDbSetTypes<TDbContext>(this TDbContext dbContext)
            where TDbContext : DbContext
        {
            return typeof(TDbContext).GetProperties()
                .WhereIsOfType(typeof(DbSet<>))
                .SelectMany(x => x.Key.GenericTypeArguments);
        }

        public static IEnumerable<IArchiveerbaar> GeefAlleArchiveerbareEntiteiten<TDbContext>(this TDbContext dbContext, params EntityState[] entityStates)
            where TDbContext : DbContext
        {
            return dbContext.ChangeTracker.Entries()
                .Where(e => entityStates.Contains(e.State))
                .Where(e => e.Entity is IArchiveerbaar)
                .Select(e => e.Entity as IArchiveerbaar)
                .Where(e => e != null)
                .ToList();
        }
    }    
}