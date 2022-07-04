using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller.Migrations
{
    public partial class porcentaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "porcentaje",
                table: "CotizacionReparaciones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                column: "fechaSolicitud",
                value: new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "porcentaje",
                table: "CotizacionReparaciones");

            migrationBuilder.UpdateData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                column: "fechaSolicitud",
                value: new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
