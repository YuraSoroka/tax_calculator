using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncomeTaxCalculator.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrossAnnualSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAnnualSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualTaxPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossMonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetMonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyTaxPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxResults");
        }
    }
}
