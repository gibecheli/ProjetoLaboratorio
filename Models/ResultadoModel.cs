using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class ResultadoModel
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Pedido")]
        public int PedidoId { get; set; }
        public PedidosModel Pedido { get; set; }

        [Display(Name = "Laudo")]
        public string Laudo { get; set; }

        [Display(Name = "Data do Laudo")]
        public DateTime DataLaudo { get; set; } = DateTime.Today;

        public string EmailCliente { get; set; }
    }
}
