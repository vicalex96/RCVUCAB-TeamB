using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller.Migrations
{
    public partial class cotizacionReparacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                column: "fechaSolicitud",
                value: new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "SolicitudReparacions",
                columns: new[] { "solicitudRepId", "fechaSolicitud", "incidenteId", "tallerId", "vehiculoId" },
                values: new object[,]
                {
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c01b"), new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000000-d5ef-46c7-bc0e-97530823c04b"), new Guid("10003262-d5ef-46c7-bc0e-97530823c05b"), new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c02b"), new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000000-d5ef-46c7-bc0e-97530823c03b"), new Guid("10003262-d5ef-46c7-bc0e-97530823c05b"), new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c06b"), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000000-d5ef-46c7-bc0e-97530823c06b"), new Guid("30003262-d5ef-46c7-bc0e-97530823c05b"), new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c11b"), new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000000-d5ef-46c7-bc0e-97530823c11b"), new Guid("30003262-d5ef-46c7-bc0e-97530823c05b"), new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c12b"), new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000000-d5ef-46c7-bc0e-97530823c12b"), new Guid("20003262-d5ef-46c7-bc0e-97530823c05b"), new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c01b"));

            migrationBuilder.DeleteData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c02b"));

            migrationBuilder.DeleteData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c06b"));

            migrationBuilder.DeleteData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c11b"));

            migrationBuilder.DeleteData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c12b"));

            migrationBuilder.UpdateData(
                table: "SolicitudReparacions",
                keyColumn: "solicitudRepId",
                keyValue: new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                column: "fechaSolicitud",
                value: new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
