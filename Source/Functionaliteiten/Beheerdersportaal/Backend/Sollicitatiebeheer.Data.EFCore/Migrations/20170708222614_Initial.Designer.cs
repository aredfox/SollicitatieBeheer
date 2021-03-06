﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Sollicitatiebeheer.Data.EFCore;
using System;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    [DbContext(typeof(SollicitatiebeheerDatabase))]
    [Migration("20170708222614_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-25794")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beheerdersportaal.Model.Afdelingen.Afdeling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<string>("Naam");

                    b.Property<DateTime>("TijdstipAangemaaktUtc");

                    b.Property<DateTime>("TijdstipLaatstGewijzigdUtc");

                    b.HasKey("Id");

                    b.ToTable("Afdelingen");
                });

            modelBuilder.Entity("Beheerdersportaal.Model.Functies.Functie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<string>("Naam");

                    b.Property<DateTime>("TijdstipAangemaaktUtc");

                    b.Property<DateTime>("TijdstipLaatstGewijzigdUtc");

                    b.HasKey("Id");

                    b.ToTable("Functies");
                });

            modelBuilder.Entity("Beheerdersportaal.Model.Vacatures.Vacature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AfdelingId");

                    b.Property<int>("FunctieId");

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<long>("Nummer");

                    b.Property<string>("Omschrijving");

                    b.Property<DateTime>("TijdstipAangemaaktUtc");

                    b.Property<DateTime>("TijdstipLaatstGewijzigdUtc");

                    b.HasKey("Id");

                    b.HasIndex("AfdelingId");

                    b.HasIndex("FunctieId");

                    b.ToTable("Vacatures");
                });

            modelBuilder.Entity("Beheerdersportaal.Model.Vacatures.Vacature", b =>
                {
                    b.HasOne("Beheerdersportaal.Model.Afdelingen.Afdeling", "Afdeling")
                        .WithMany()
                        .HasForeignKey("AfdelingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Beheerdersportaal.Model.Functies.Functie", "Functie")
                        .WithMany()
                        .HasForeignKey("FunctieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
