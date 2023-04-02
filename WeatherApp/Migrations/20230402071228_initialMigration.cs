using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherApp.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cityview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sehir_adi = table.Column<string>(type: "text", nullable: false),
                    durum = table.Column<string>(type: "text", nullable: false),
                    tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    mak = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sehir",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sehir_adi = table.Column<string>(type: "text", nullable: false),
                    plaka_no = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sehir_havadurumu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sehir_id = table.Column<int>(type: "integer", nullable: false),
                    tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durum = table.Column<string>(type: "text", nullable: false),
                    mak = table.Column<int>(type: "integer", nullable: false),
                    kayit_tarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehir_havadurumu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sehir_havadurumu_sehir_sehir_id",
                        column: x => x.sehir_id,
                        principalTable: "sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sehir_havadurumu_sehir_id",
                table: "sehir_havadurumu",
                column: "sehir_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityview");

            migrationBuilder.DropTable(
                name: "sehir_havadurumu");

            migrationBuilder.DropTable(
                name: "sehir");
        }
    }
}
