using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CedroRestaurante.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbRestaurante",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKRestaurante", x => x.IdRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "tbPrato",
                columns: table => new
                {
                    IdPrato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    IdRestaurante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKPrato", x => x.IdPrato);
                    table.ForeignKey(
                        name: "FKRESTAURANTEPRATO",
                        column: x => x.IdRestaurante,
                        principalTable: "tbRestaurante",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbPrato_IdRestaurante",
                table: "tbPrato",
                column: "IdRestaurante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbPrato");

            migrationBuilder.DropTable(
                name: "tbRestaurante");
        }
    }
}
