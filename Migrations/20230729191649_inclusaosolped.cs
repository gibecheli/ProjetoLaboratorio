using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class inclusaosolped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SolicitanteId",
                table: "Pedidos",
                type: "nvarchar(14)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SolicitanteId",
                table: "Pedidos",
                column: "SolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Solicitantes_SolicitanteId",
                table: "Pedidos",
                column: "SolicitanteId",
                principalTable: "Solicitantes",
                principalColumn: "CpfCnpj",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Solicitantes_SolicitanteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_SolicitanteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "Pedidos");
        }
    }
}
