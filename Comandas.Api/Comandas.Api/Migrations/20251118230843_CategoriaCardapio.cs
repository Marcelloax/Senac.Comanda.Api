using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Comandas.Api.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaCardapioId",
                table: "CardapioItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaCardapios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCardapios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CardapioItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaCardapioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CardapioItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaCardapioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CardapioItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoriaCardapioId",
                value: null);

            migrationBuilder.InsertData(
                table: "CategoriaCardapios",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Lanches" },
                    { 2, null, "Bebidas" },
                    { 3, null, "Acompanhamentos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapioItems_CategoriaCardapioId",
                table: "CardapioItems",
                column: "CategoriaCardapioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioItems_CategoriaCardapios_CategoriaCardapioId",
                table: "CardapioItems",
                column: "CategoriaCardapioId",
                principalTable: "CategoriaCardapios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardapioItems_CategoriaCardapios_CategoriaCardapioId",
                table: "CardapioItems");

            migrationBuilder.DropTable(
                name: "CategoriaCardapios");

            migrationBuilder.DropIndex(
                name: "IX_CardapioItems_CategoriaCardapioId",
                table: "CardapioItems");

            migrationBuilder.DropColumn(
                name: "CategoriaCardapioId",
                table: "CardapioItems");
        }
    }
}
