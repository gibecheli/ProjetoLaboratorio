﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoLaboratorio.Data;

#nullable disable

namespace ProjetoLaboratorio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnaliseModelTipoAnaliseModel", b =>
                {
                    b.Property<int>("AnalisesId")
                        .HasColumnType("int");

                    b.Property<int>("TiposAnaliseTipoAnaliseId")
                        .HasColumnType("int");

                    b.HasKey("AnalisesId", "TiposAnaliseTipoAnaliseId");

                    b.HasIndex("TiposAnaliseTipoAnaliseId");

                    b.ToTable("AnaliseModelTipoAnaliseModel");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.AnaliseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Analises");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.ClienteModel", b =>
                {
                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePropriedade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.HasKey("CpfCnpj");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.FinanceiroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientesCpfCnpj")
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidosId")
                        .HasColumnType("int");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientesCpfCnpj");

                    b.HasIndex("PedidosId");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.PedidoModel", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"), 1L, 1);

                    b.Property<int>("AnaliseId")
                        .HasColumnType("int");

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("TipoAnaliseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("PedidoId");

                    b.HasIndex("AnaliseId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoAnaliseId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.RelatorioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataRelatorio")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalAnalisesPorPeriodo")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorFinanceiroPorPeriodo")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.ResultadoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataLaudo")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Laudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.SolicitanteModel", b =>
                {
                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.HasKey("CpfCnpj");

                    b.ToTable("Solicitantes");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.TipoAnaliseModel", b =>
                {
                    b.Property<int>("TipoAnaliseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoAnaliseId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAnalise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("TipoAnaliseId");

                    b.ToTable("TipoAnalises");
                });

            modelBuilder.Entity("AnaliseModelTipoAnaliseModel", b =>
                {
                    b.HasOne("ProjetoLaboratorio.Models.AnaliseModel", null)
                        .WithMany()
                        .HasForeignKey("AnalisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoLaboratorio.Models.TipoAnaliseModel", null)
                        .WithMany()
                        .HasForeignKey("TiposAnaliseTipoAnaliseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.FinanceiroModel", b =>
                {
                    b.HasOne("ProjetoLaboratorio.Models.ClienteModel", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesCpfCnpj");

                    b.HasOne("ProjetoLaboratorio.Models.PedidoModel", "Pedidos")
                        .WithMany("Financeiros")
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.PedidoModel", b =>
                {
                    b.HasOne("ProjetoLaboratorio.Models.AnaliseModel", "Analise")
                        .WithMany("Pedidos")
                        .HasForeignKey("AnaliseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoLaboratorio.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoLaboratorio.Models.TipoAnaliseModel", "TipoAnalise")
                        .WithMany()
                        .HasForeignKey("TipoAnaliseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analise");

                    b.Navigation("Cliente");

                    b.Navigation("TipoAnalise");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.ResultadoModel", b =>
                {
                    b.HasOne("ProjetoLaboratorio.Models.PedidoModel", "Pedido")
                        .WithMany("Resultados")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.AnaliseModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ProjetoLaboratorio.Models.PedidoModel", b =>
                {
                    b.Navigation("Financeiros");

                    b.Navigation("Resultados");
                });
#pragma warning restore 612, 618
        }
    }
}
