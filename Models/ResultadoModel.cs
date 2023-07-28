using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLaboratorio.Models
{
    [Table("Resultados")]
    public class ResultadoModel
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Pedido")]
        public int PedidoId { get; set; }
        public PedidoModel Pedido { get; set; }

        [Display(Name = "Laudo:")]
        [DataType(DataType.Html)]
        public string Laudo { get; set; }

        [Display(Name = "Data do Laudo")]
        public DateTime DataLaudo { get; set; } = DateTime.Today;

        public string EmailCliente { get; set; }
    }
}
