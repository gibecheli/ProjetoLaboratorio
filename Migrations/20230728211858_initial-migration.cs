using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analises_TipoAnalise_TipoAnalisesModelTipoAnaliseId",
                table: "Analises");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Solicitantes_SolicitanteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatorio_Pedidos_PedidosModelPedidoId",
                table: "Relatorio");

            migrationBuilder.DropIndex(
                name: "IX_Relatorio_PedidosModelPedidoId",
                table: "Relatorio");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_SolicitanteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Analises_TipoAnalisesModelTipoAnaliseId",
                table: "Analises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "PedidosModelPedidoId",
                table: "Relatorio");

            migrationBuilder.DropColumn(
                name: "ClienteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SolicitanteCpfCnpj",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoAnaliseIdSelecionado",
                table: "Analises");

            migrationBuilder.DropColumn(
                name: "TipoAnalisesModelTipoAnaliseId",
                table: "Analises");

            migrationBuilder.RenameColumn(
                name: "TipoAnalises",
                table: "TipoAnalise",
                newName: "TipoAnalise");

            migrationBuilder.RenameColumn(
                name: "DataDeCadastro",
                table: "Solicitantes",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "DataDoCadastro",
                table: "Clientes",
                newName: "DataCadastro");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPessoa",
                table: "Solicitantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Solicitantes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Solicitantes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Solicitantes",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Solicitantes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Solicitantes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Solicitantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Solicitantes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Solicitantes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "Pedidos",
                type: "nvarchar(14)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ClientesCpfCnpj",
                table: "Financeiro",
                type: "nvarchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoPessoa",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomePropriedade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Clientes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "AnaliseModelTipoAnaliseModel",
                columns: table => new
                {
                    AnalisesId = table.Column<int>(type: "int", nullable: false),
                    TiposAnaliseTipoAnaliseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseModelTipoAnaliseModel", x => new { x.AnalisesId, x.TiposAnaliseTipoAnaliseId });
                    table.ForeignKey(
                        name: "FK_AnaliseModelTipoAnaliseModel_Analises_AnalisesId",
                        column: x => x.AnalisesId,
                        principalTable: "Analises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalise_TiposAnaliseTipoAnaliseId",
                        column: x => x.TiposAnaliseTipoAnaliseId,
                        principalTable: "TipoAnalise",
                        principalColumn: "TipoAnaliseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseModelTipoAnaliseModel_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel",
                column: "TiposAnaliseTipoAnaliseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "CpfCnpj",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "AnaliseModelTipoAnaliseModel");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "TipoAnalise",
                table: "TipoAnalise",
                newName: "TipoAnalises");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Solicitantes",
                newName: "DataDeCadastro");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Clientes",
                newName: "DataDoCadastro");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPessoa",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Solicitantes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Solicitantes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Solicitantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PedidosModelPedidoId",
                table: "Relatorio",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)");

            migrationBuilder.AddColumn<string>(
                name: "ClienteCpfCnpj",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolicitanteCpfCnpj",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SolicitanteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ClientesCpfCnpj",
                table: "Financeiro",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoPessoa",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomePropriedade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoAnaliseIdSelecionado",
                table: "Analises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoAnalisesModelTipoAnaliseId",
                table: "Analises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_PedidosModelPedidoId",
                table: "Relatorio",
                column: "PedidosModelPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteCpfCnpj",
                table: "Pedidos",
                column: "ClienteCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SolicitanteCpfCnpj",
                table: "Pedidos",
                column: "SolicitanteCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Analises_TipoAnalisesModelTipoAnaliseId",
                table: "Analises",
                column: "TipoAnalisesModelTipoAnaliseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analises_TipoAnalise_TipoAnalisesModelTipoAnaliseId",
                table: "Analises",
                column: "TipoAnalisesModelTipoAnaliseId",
                principalTable: "TipoAnalise",
                principalColumn: "TipoAnaliseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteCpfCnpj",
                table: "Pedidos",
                column: "ClienteCpfCnpj",
                principalTable: "Clientes",
                principalColumn: "CpfCnpj");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Solicitantes_SolicitanteCpfCnpj",
                table: "Pedidos",
                column: "SolicitanteCpfCnpj",
                principalTable: "Solicitantes",
                principalColumn: "CpfCnpj",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorio_Pedidos_PedidosModelPedidoId",
                table: "Relatorio",
                column: "PedidosModelPedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }
    }
}
