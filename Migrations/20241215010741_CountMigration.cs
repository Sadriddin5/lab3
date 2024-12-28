using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysProgLab3.Migrations
{
    /// <inheritdoc />
    public partial class CountMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyUsers",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUsers", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "PriceCurants",
                columns: table => new
                {
                    CodeGood = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceGood = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCurants", x => x.CodeGood);
                });

            migrationBuilder.CreateTable(
                name: "AccountingGoods",
                columns: table => new
                {
                    IDCounting = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeGood = table.Column<long>(type: "bigint", nullable: false),
                    NameGood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountOfSold = table.Column<int>(type: "int", nullable: false),
                    PriceGood = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceCurantCodeGood = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingGoods", x => x.IDCounting);
                    table.ForeignKey(
                        name: "FK_AccountingGoods_PriceCurants_PriceCurantCodeGood",
                        column: x => x.PriceCurantCodeGood,
                        principalTable: "PriceCurants",
                        principalColumn: "CodeGood");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingGoods_PriceCurantCodeGood",
                table: "AccountingGoods",
                column: "PriceCurantCodeGood");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingGoods");

            migrationBuilder.DropTable(
                name: "MyUsers");

            migrationBuilder.DropTable(
                name: "PriceCurants");
        }
    }
}
