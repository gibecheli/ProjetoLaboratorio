using Microsoft.EntityFrameworkCore;
using ProjetoLaboratorio.Models;

namespace ProjetoLaboratorio.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<SolicitanteModel> Solicitantes { get; set; }
        public DbSet<AnaliseModel> Analises { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<TipoAnaliseModel> TipoAnalise { get; set; }
        public DbSet<FinanceiroModel> Financeiro { get; set; }
        public DbSet<RelatorioModel> Relatorio { get; set; }
        public DbSet<ResultadoModel> Resultado { get; set; }
        public object Users { get; internal set; }
    }
}
