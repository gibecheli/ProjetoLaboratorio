using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class correcoes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalise_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TipoAnalise_TipoAnaliseId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Pedidos_PedidoId",
                table: "Resultado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoAnalise",
                table: "TipoAnalise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resultado",
                table: "Resultado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio");

            migrationBuilder.RenameTable(
                name: "TipoAnalise",
                newName: "TipoAnalises");

            migrationBuilder.RenameTable(
                name: "Resultado",
                newName: "Resultados");

            migrationBuilder.RenameTable(
                name: "Relatorio",
                newName: "Relatorios");

            migrationBuilder.RenameIndex(
                name: "IX_Resultado_PedidoId",
                table: "Resultados",
                newName: "IX_Resultados_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoAnalises",
                table: "TipoAnalises",
                column: "TipoAnaliseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resultados",
                table: "Resultados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorios",
                table: "Relatorios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalises_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel",
                column: "TiposAnaliseTipoAnaliseId",
                principalTable: "TipoAnalises",
                principalColumn: "TipoAnaliseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TipoAnalises_TipoAnaliseId",
                table: "Pedidos",
                column: "TipoAnaliseId",
                principalTable: "TipoAnalises",
                principalColumn: "TipoAnaliseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_Pedidos_PedidoId",
                table: "Resultados",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalises_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TipoAnalises_TipoAnaliseId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_Pedidos_PedidoId",
                table: "Resultados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoAnalises",
                table: "TipoAnalises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resultados",
                table: "Resultados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorios",
                table: "Relatorios");

            migrationBuilder.RenameTable(
                name: "TipoAnalises",
                newName: "TipoAnalise");

            migrationBuilder.RenameTable(
                name: "Resultados",
                newName: "Resultado");

            migrationBuilder.RenameTable(
                name: "Relatorios",
                newName: "Relatorio");

            migrationBuilder.RenameIndex(
                name: "IX_Resultados_PedidoId",
                table: "Resultado",
                newName: "IX_Resultado_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoAnalise",
                table: "TipoAnalise",
                column: "TipoAnaliseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resultado",
                table: "Resultado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalise_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel",
                column: "TiposAnaliseTipoAnaliseId",
                principalTable: "TipoAnalise",
                principalColumn: "TipoAnaliseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TipoAnalise_TipoAnaliseId",
                table: "Pedidos",
                column: "TipoAnaliseId",
                principalTable: "TipoAnalise",
                principalColumn: "TipoAnaliseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Pedidos_PedidoId",
                table: "Resultado",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
