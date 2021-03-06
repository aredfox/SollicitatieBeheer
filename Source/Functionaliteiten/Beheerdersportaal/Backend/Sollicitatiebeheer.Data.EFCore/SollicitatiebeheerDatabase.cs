﻿using Beheerdersportaal.Model.Afdelingen;
using Beheerdersportaal.Model.Functies;
using Beheerdersportaal.Model.Gedeeld;
using Beheerdersportaal.Model.Vacatures;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Data.EFCore.Infrastructuur;
using System;
using System.Linq;

namespace Sollicitatiebeheer.Data.EFCore
{
    public class SollicitatiebeheerDatabase : DbContext
    {
        public DbSet<Afdeling> Afdelingen { get; set; }
        public DbSet<Functie> Functies { get; set; }
        public DbSet<Vacature> Vacatures { get; set; }

        public SollicitatiebeheerDatabase() 
            : this(new DefaultDbContextFactory().CreateDefaultOptions()) { }
        public SollicitatiebeheerDatabase(DbContextOptions<SollicitatiebeheerDatabase> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(new DefaultDbContextFactory().GetConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            ConfigureerIdentityColumns(modelBuilder);
            //ConfigureerArchiveerbareEntiteiten(modelBuilder);

            modelBuilder.Entity<Vacature>(v =>
            {
                v.HasOne(p => p.Afdeling).WithMany().HasForeignKey(x => x.AfdelingId);
                v.HasOne(p => p.Functie).WithMany().HasForeignKey(x => x.FunctieId);
            });
        }

        private void ConfigureerIdentityColumns(ModelBuilder modelBuilder)
        {
            this.GeefAlleDbSetTypes().ToList()
                .ForEach(t => {
                    Console.WriteLine($"Mapping type '{t.Name.ToString()}'.");                    

                    if (typeof(IEntiteit).IsAssignableFrom(t))
                    {
                        Console.WriteLine($" Type '{t.Name.ToString()}' is IEntiteit.");
                        modelBuilder.Entity(t, e => e.HasKey("Id"));
                        UseSqlServerIdentityColumnVoor(t, modelBuilder);
                    }
                });
        }
        private void ConfigureerArchiveerbareEntiteiten(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IArchiveerbaar>()
                .HasQueryFilter(p => !p.IsGearchiveerd);
        }
        private void UseSqlServerIdentityColumnVoor(Type type, ModelBuilder modelBuilder)
        {
            if (typeof(IEntiteit<int>).IsAssignableFrom(type) || typeof(IEntiteit<long>).IsAssignableFrom(type))
            {
                modelBuilder.Entity(type, e =>
                {
                    e.Property(nameof(IEntiteit.Id)).UseSqlServerIdentityColumn();
                });
            }
        }

        public override int SaveChanges()
        {
            this.GeefAlleArchiveerbareEntiteiten(EntityState.Deleted).ToList()
                .ForEach(ae =>
                {
                    ae.IsGearchiveerd = true;
                });

            this.GeefAlleArchiveerbareEntiteiten(EntityState.Modified).ToList()            
                .ForEach(ae =>
                {
                    ae.TijdstipLaatstGewijzigdUtc = DateTime.UtcNow;                    
                });

            this.GeefAlleArchiveerbareEntiteiten(EntityState.Added).ToList()
                .ForEach(ae => {
                    ae.TijdstipAangemaaktUtc = DateTime.UtcNow;
                    ae.TijdstipLaatstGewijzigdUtc = DateTime.UtcNow;
                });

            return base.SaveChanges();
        }               
    }
}
