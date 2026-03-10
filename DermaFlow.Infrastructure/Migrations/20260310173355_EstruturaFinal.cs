using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DermaFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Agendamentos",
                newName: "PacienteId");

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Agendamentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraFim",
                table: "Agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AgendamentoProcedimento",
                columns: table => new
                {
                    AgendamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedimentosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoProcedimento", x => new { x.AgendamentoId, x.ProcedimentosId });
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Agendamentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Procedimentos_ProcedimentosId",
                        column: x => x.ProcedimentosId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_ProcedimentosId",
                table: "AgendamentoProcedimento",
                column: "ProcedimentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ClinicId",
                table: "Pacientes",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropTable(
                name: "AgendamentoProcedimento");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraFim",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Agendamentos",
                newName: "ClienteId");
        }
    }
}
