using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebScrapping.Infrastructure.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ScientificName = table.Column<string>(type: "text", nullable: true),
                    Group = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FoodComposition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodCode = table.Column<string>(type: "text", nullable: false),
                    Component = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    ValuePer100g = table.Column<decimal>(type: "numeric", nullable: true),
                    StandardDeviation = table.Column<decimal>(type: "numeric", nullable: true),
                    MinimumValue = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumValue = table.Column<decimal>(type: "numeric", nullable: true),
                    NumberOfDataUsed = table.Column<int>(type: "integer", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    DataType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodComposition_Foods_FoodCode",
                        column: x => x.FoodCode,
                        principalTable: "Foods",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodComposition_FoodCode",
                table: "FoodComposition",
                column: "FoodCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodComposition");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
