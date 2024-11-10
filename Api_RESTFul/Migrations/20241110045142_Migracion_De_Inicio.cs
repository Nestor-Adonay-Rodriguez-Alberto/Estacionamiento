using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_RESTFul.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_De_Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposEstacionamientos",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstacionamientos", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "AlquilerEstacionamiento",
                columns: table => new
                {
                    IdAlquiler = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoEstacionamientoEnAlquiler = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlquilerEstacionamiento", x => x.IdAlquiler);
                    table.ForeignKey(
                        name: "FK_AlquilerEstacionamiento_TiposEstacionamientos_IdTipoEstacionamientoEnAlquiler",
                        column: x => x.IdTipoEstacionamientoEnAlquiler,
                        principalTable: "TiposEstacionamientos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlquilerEstacionamiento_IdTipoEstacionamientoEnAlquiler",
                table: "AlquilerEstacionamiento",
                column: "IdTipoEstacionamientoEnAlquiler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlquilerEstacionamiento");

            migrationBuilder.DropTable(
                name: "TiposEstacionamientos");
        }
    }
}
