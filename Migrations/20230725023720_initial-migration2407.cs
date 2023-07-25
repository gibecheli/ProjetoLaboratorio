using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class initialmigration2407 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePropriedade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CpfCnpj);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    CpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.CpfCnpj);
                });

            migrationBuilder.CreateTable(
                name: "TipoAnalise",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnalises = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false),
                    AnalisesModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnalise", x => x.TipoId);
                    table.ForeignKey(
                        name: "FK_TipoAnalise_Analises_AnalisesModelId",
                        column: x => x.AnalisesModelId,
                        principalTable: "Analises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientesModelCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientesModelId = table.Column<int>(type: "int", nullable: false),
                    SolicitanteModelCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteModelId = table.Column<int>(type: "int", nullable: false),
                    AnalisesModelId = table.Column<int>(type: "int", nullable: false),
                    TipoAnalisesModelId = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Analises_AnalisesModelId",
                        column: x => x.AnalisesModelId,
                        principalTable: "Analises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClientesModelCpfCnpj",
                        column: x => x.ClientesModelCpfCnpj,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpj");
                    table.ForeignKey(
                        name: "FK_Pedidos_Solicitantes_SolicitanteModelCpfCnpj",
                        column: x => x.SolicitanteModelCpfCnpj,
                        principalTable: "Solicitantes",
                        principalColumn: "CpfCnpj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_TipoAnalise_TipoAnalisesModelId",
                        column: x => x.TipoAnalisesModelId,
                        principalTable: "TipoAnalise",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    ClientesCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValorTotal = table.Column<float>(type: "real", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finalizado = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financeiro_Clientes_ClientesCpfCnpj",
                        column: x => x.ClientesCpfCnpj,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpj");
                    table.ForeignKey(
                        name: "FK_Financeiro_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLaudo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultado_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultadoId = table.Column<int>(type: "int", nullable: false),
                    LaudoId = table.Column<int>(type: "int", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRelatorio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorio_Resultado_LaudoId",
                        column: x => x.LaudoId,
                        principalTable: "Resultado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_ClientesCpfCnpj",
                table: "Financeiro",
                column: "ClientesCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_PedidosId",
                table: "Financeiro",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AnalisesModelId",
                table: "Pedidos",
                column: "AnalisesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesModelCpfCnpj",
                table: "Pedidos",
                column: "ClientesModelCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SolicitanteModelCpfCnpj",
                table: "Pedidos",
                column: "SolicitanteModelCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoAnalisesModelId",
                table: "Pedidos",
                column: "TipoAnalisesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_LaudoId",
                table: "Relatorio",
                column: "LaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_PedidoId",
                table: "Resultado",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAnalise_AnalisesModelId",
                table: "TipoAnalise",
                column: "AnalisesModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropTable(
                name: "TipoAnalise");

            migrationBuilder.DropTable(
                name: "Analises");
        }
    }
}
