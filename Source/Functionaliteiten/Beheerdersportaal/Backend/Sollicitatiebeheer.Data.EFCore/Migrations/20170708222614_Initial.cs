using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afdelingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsGearchiveerd = table.Column<bool>(type: "bit", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TijdstipAangemaaktUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TijdstipLaatstGewijzigdUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdelingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsGearchiveerd = table.Column<bool>(type: "bit", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TijdstipAangemaaktUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TijdstipLaatstGewijzigdUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AfdelingId = table.Column<int>(type: "int", nullable: false),
                    FunctieId = table.Column<int>(type: "int", nullable: false),
                    IsGearchiveerd = table.Column<bool>(type: "bit", nullable: false),
                    Nummer = table.Column<long>(type: "bigint", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TijdstipAangemaaktUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TijdstipLaatstGewijzigdUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacatures_Afdelingen_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdelingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacatures_Functies_FunctieId",
                        column: x => x.FunctieId,
                        principalTable: "Functies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacatures_AfdelingId",
                table: "Vacatures",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacatures_FunctieId",
                table: "Vacatures",
                column: "FunctieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacatures");

            migrationBuilder.DropTable(
                name: "Afdelingen");

            migrationBuilder.DropTable(
                name: "Functies");
        }
    }
}
