using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    public partial class initialmigration : Migration
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
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAnalisesPorPeriodo = table.Column<int>(type: "int", nullable: false),
                    ValorFinanceiroPorPeriodo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataRelatorio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    CpfCnpjS = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.CpfCnpjS);
                });

            migrationBuilder.CreateTable(
                name: "TipoAnalises",
                columns: table => new
                {
                    TipoAnaliseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnalise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnalises", x => x.TipoAnaliseId);
                });

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
                        name: "FK_AnaliseModelTipoAnaliseModel_TipoAnalises_TiposAnaliseTipoAnaliseId",
                        column: x => x.TiposAnaliseTipoAnaliseId,
                        principalTable: "TipoAnalises",
                        principalColumn: "TipoAnaliseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CpfCnpjC = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscEstRG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePropriedade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConvenioId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CpfCnpjC);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desconto = table.Column<float>(type: "real", nullable: false),
                    ClienteModelCpfCnpjC = table.Column<string>(type: "nvarchar(18)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convenios_Clientes_ClienteModelCpfCnpjC",
                        column: x => x.ClienteModelCpfCnpjC,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpjC");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CpfCnpjC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteCpfCnpjC = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    CpfCnpjS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitanteCpfCnpjS = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    AnaliseId = table.Column<int>(type: "int", nullable: false),
                    TipoAnaliseId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_Pedidos_Clientes_ClienteCpfCnpjC",
                        column: x => x.ClienteCpfCnpjC,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpjC");
                    table.ForeignKey(
                        name: "FK_Pedidos_Solicitantes_SolicitanteCpfCnpjS",
                        column: x => x.SolicitanteCpfCnpjS,
                        principalTable: "Solicitantes",
                        principalColumn: "CpfCnpjS");
                    table.ForeignKey(
                        name: "FK_Pedidos_TipoAnalises_TipoAnaliseId",
                        column: x => x.TipoAnaliseId,
                        principalTable: "TipoAnalises",
                        principalColumn: "TipoAnaliseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    ClientesCpfCnpjC = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financeiro_Clientes_ClientesCpfCnpjC",
                        column: x => x.ClientesCpfCnpjC,
                        principalTable: "Clientes",
                        principalColumn: "CpfCnpjC");
                    table.ForeignKey(
                        name: "FK_Financeiro_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
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
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseModelTipoAnaliseModel_TiposAnaliseTipoAnaliseId",
                table: "AnaliseModelTipoAnaliseModel",
                column: "TiposAnaliseTipoAnaliseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ConvenioId",
                table: "Clientes",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_ClienteModelCpfCnpjC",
                table: "Convenios",
                column: "ClienteModelCpfCnpjC");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_ClientesCpfCnpjC",
                table: "Financeiro",
                column: "ClientesCpfCnpjC");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_PedidosId",
                table: "Financeiro",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AnaliseId",
                table: "Pedidos",
                column: "AnaliseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteCpfCnpjC",
                table: "Pedidos",
                column: "ClienteCpfCnpjC");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SolicitanteCpfCnpjS",
                table: "Pedidos",
                column: "SolicitanteCpfCnpjS");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoAnaliseId",
                table: "Pedidos",
                column: "TipoAnaliseId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_PedidoId",
                table: "Resultados",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Convenios_ConvenioId",
                table: "Clientes",
                column: "ConvenioId",
                principalTable: "Convenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Convenios_ConvenioId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "AnaliseModelTipoAnaliseModel");

            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Analises");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropTable(
                name: "TipoAnalises");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
