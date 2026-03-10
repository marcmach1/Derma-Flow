using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DermaFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriarEstruturaAgendamentoCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Procedimentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "DuracaoMinutos",
                table: "Procedimentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Procedimentos");
        }
    }
}
