using Microsoft.EntityFrameworkCore;
using ProjetoLaboratorio.Models;

namespace ProjetoLaboratorio.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<SolicitanteModel> Solicitantes { get; set; }
        public DbSet<AnalisesModel> Analises { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<TipoAnalisesModel> TipoAnalise { get; set; }
        public DbSet<FinanceiroModel> Financeiro { get; set; }
        public DbSet<RelatoriosModel> Relatorio { get; set; }
        public DbSet<LaudosModel> Laudo { get; set; }


    }
}
