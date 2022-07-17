using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commify.TaxCalculator.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SalaryLowerLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    SalaryUpperLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    TaxRate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "Name", "SalaryLowerLimit", "SalaryUpperLimit", "TaxRate" },
                values: new object[] { new Guid("162811d6-91ff-41be-9a5c-493d3ffca94b"), "TaxBandC", 20000, null, 40 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "Name", "SalaryLowerLimit", "SalaryUpperLimit", "TaxRate" },
                values: new object[] { new Guid("4dff37d1-c1c5-4cbe-85b7-0f484578ce19"), "TaxBandB", 5000, 20000, 20 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "Name", "SalaryLowerLimit", "SalaryUpperLimit", "TaxRate" },
                values: new object[] { new Guid("73eaa000-bd7c-4337-87b4-80c3b1c80ab4"), "TaxBandA", 0, 5000, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");
        }
    }
}
