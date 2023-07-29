using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppVitalSignMonitor.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdDispositivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreDispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Tokken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteIdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdDispositivo);
                    table.ForeignKey(
                        name: "FK_Paciente_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Pacientes_PacienteIdUsuario",
                        column: x => x.PacienteIdUsuario,
                        principalTable: "Pacientes",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Paciente_Usuarios_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alarmas",
                columns: table => new
                {
                    IdAlarma = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreadorIdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PacienteIdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DispositivoIdDispositivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValorComparativo = table.Column<float>(type: "real", nullable: false),
                    TipoAlarma = table.Column<int>(type: "int", nullable: false),
                    TipoComparacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmas", x => x.IdAlarma);
                    table.ForeignKey(
                        name: "FK_Alarmas_Paciente_DispositivoIdDispositivo",
                        column: x => x.DispositivoIdDispositivo,
                        principalTable: "Paciente",
                        principalColumn: "IdDispositivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarmas_Pacientes_PacienteIdUsuario",
                        column: x => x.PacienteIdUsuario,
                        principalTable: "Pacientes",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Alarmas_Usuarios_CreadorIdUsuario",
                        column: x => x.CreadorIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    IdDispositivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PacienteIdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DispositivoIdDispositivo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PresionDiastolica = table.Column<float>(type: "real", nullable: true),
                    PresionSistolica = table.Column<float>(type: "real", nullable: true),
                    SaturacionOxigeno = table.Column<int>(type: "int", nullable: true),
                    Temperatura = table.Column<float>(type: "real", nullable: true),
                    Pulso = table.Column<int>(type: "int", nullable: true),
                    HoraFecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.IdDispositivo);
                    table.ForeignKey(
                        name: "FK_Reportes_Paciente_DispositivoIdDispositivo",
                        column: x => x.DispositivoIdDispositivo,
                        principalTable: "Paciente",
                        principalColumn: "IdDispositivo");
                    table.ForeignKey(
                        name: "FK_Reportes_Pacientes_PacienteIdUsuario",
                        column: x => x.PacienteIdUsuario,
                        principalTable: "Pacientes",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmas_CreadorIdUsuario",
                table: "Alarmas",
                column: "CreadorIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmas_DispositivoIdDispositivo",
                table: "Alarmas",
                column: "DispositivoIdDispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmas_PacienteIdUsuario",
                table: "Alarmas",
                column: "PacienteIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CreadorId",
                table: "Paciente",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PacienteId",
                table: "Paciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PacienteIdUsuario",
                table: "Paciente",
                column: "PacienteIdUsuario",
                unique: true,
                filter: "[PacienteIdUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_DispositivoIdDispositivo",
                table: "Reportes",
                column: "DispositivoIdDispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_PacienteIdUsuario",
                table: "Reportes",
                column: "PacienteIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Alarmas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
