using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace administracion.Migrations
{
    public partial class datos_asegurados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asegurados",
                columns: table => new
                {
                    aseguradoId = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asegurados", x => x.aseguradoId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    vehiculoId = table.Column<Guid>(type: "uuid", nullable: false),
                    anioModelo = table.Column<int>(type: "integer", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    color = table.Column<int>(type: "integer", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false),
                    marca = table.Column<int>(type: "integer", nullable: false),
                    aseguradoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.vehiculoId);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Asegurados_aseguradoId",
                        column: x => x.aseguradoId,
                        principalTable: "Asegurados",
                        principalColumn: "aseguradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    polizaId = table.Column<Guid>(type: "uuid", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fechaVencimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tipoPoliza = table.Column<int>(type: "integer", nullable: false),
                    vehiculoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.polizaId);
                    table.ForeignKey(
                        name: "FK_Polizas_Vehiculos_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "vehiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incidentes",
                columns: table => new
                {
                    incidenteId = table.Column<Guid>(type: "uuid", nullable: false),
                    polizaId = table.Column<Guid>(type: "uuid", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidentes", x => x.incidenteId);
                    table.ForeignKey(
                        name: "FK_incidentes_Polizas_polizaId",
                        column: x => x.polizaId,
                        principalTable: "Polizas",
                        principalColumn: "polizaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Asegurados",
                columns: new[] { "aseguradoId", "apellido", "nombre" },
                values: new object[,]
                {
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c03b"), "Ramirez Gimenez", "Luis Jose" },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c03f"), "Banderas Lopez", "Manuel Diego" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "vehiculoId", "anioModelo", "aseguradoId", "color", "fechaCompra", "marca", "placa" },
                values: new object[,]
                {
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b"), 2004, new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c03b"), 1, new DateTime(2022, 6, 15, 21, 0, 59, 388, DateTimeKind.Local).AddTicks(6756), 0, "AB320AM" },
                    { new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c05b"), 2006, new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c03f"), 6, new DateTime(2022, 6, 15, 21, 0, 59, 388, DateTimeKind.Local).AddTicks(6770), 0, "AB322AM" }
                });

            migrationBuilder.InsertData(
                table: "Polizas",
                columns: new[] { "polizaId", "fechaInicio", "fechaVencimiento", "tipoPoliza", "vehiculoId" },
                values: new object[] { new Guid("0c5c3262-d5ef-46c7-bc0e-97530823c05b"), new DateTime(2022, 6, 15, 21, 0, 59, 388, DateTimeKind.Local).AddTicks(6774), new DateTime(2022, 6, 15, 21, 0, 59, 388, DateTimeKind.Local).AddTicks(6775), 0, new Guid("0c5c3262-d5ef-46c7-bc0e-97530821c04b") });

            migrationBuilder.InsertData(
                table: "incidentes",
                columns: new[] { "incidenteId", "estado", "polizaId" },
                values: new object[] { new Guid("75045fa2-7e8d-48d4-a02f-6ea13e599984"), 0, new Guid("0c5c3262-d5ef-46c7-bc0e-97530823c05b") });

            migrationBuilder.CreateIndex(
                name: "IX_incidentes_polizaId",
                table: "incidentes",
                column: "polizaId");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_vehiculoId",
                table: "Polizas",
                column: "vehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_aseguradoId",
                table: "Vehiculos",
                column: "aseguradoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incidentes");

            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Asegurados");
        }
    }
}
