using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class LaudosModel
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ID:")]
            public int Id { get; set; }

            [Required(ErrorMessage = "O campo PedidoId é obrigatório.")]
            [Display(Name = "Pedido:")]
            public int PedidoId { get; set; }
            public PedidosModel Pedido { get; set; }

            [Required(ErrorMessage = "O campo Conteudo é obrigatório.")]
            [Display(Name = "Conteúdo:")]
            public string Conteudo { get; set; }

            [Display(Name = "Data do Laudo:")]
            public DateTime DataLaudo { get; set; } = DateTime.Now;
        }
    }