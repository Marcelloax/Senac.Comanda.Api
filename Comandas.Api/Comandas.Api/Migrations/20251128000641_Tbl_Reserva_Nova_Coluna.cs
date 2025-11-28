using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comandas.Api.Migrations
{
    /// <inheritdoc />
    public partial class Tbl_Reserva_Nova_Coluna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraReserva",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraReserva",
                table: "Reservas");
        }
    }
}
