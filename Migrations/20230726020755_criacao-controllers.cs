using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class criacaocontrollers : Migration
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
                    ClienteCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    SolicitanteCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    AnaliseId = table.Column<int>(type: "int", nullable: false),
                    TipoAnaliseId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<float>(type: "real", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Analises_AnaliseId",
                        column: x => x.AnaliseId,
                        principalTable: "Analises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteCpfCnpj",
                        column: x => x.ClienteCpfCnpj,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpj");
                    table.ForeignKey(
                        name: "FK_Pedidos_Solicitantes_SolicitanteCpfCnpj",
                        column: x => x.SolicitanteCpfCnpj,
                        principalTable: "Solicitantes",
                        principalColumn: "CpfCnpj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_TipoAnalise_TipoAnaliseId",
                        column: x => x.TipoAnaliseId,
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
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false)
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
                    Laudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLaudo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TotalAnalisesPorPeriodo = table.Column<int>(type: "int", nullable: false),
                    ValorFinanceiroPorPeriodo = table.Column<float>(type: "real", nullable: false),
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
                name: "IX_Pedidos_AnaliseId",
                table: "Pedidos",
                column: "AnaliseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteCpfCnpj",
                table: "Pedidos",
                column: "ClienteCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SolicitanteCpfCnpj",
                table: "Pedidos",
                column: "SolicitanteCpfCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoAnaliseId",
                table: "Pedidos",
                column: "TipoAnaliseId");

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
