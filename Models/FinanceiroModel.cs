using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ProjetoLaboratorio.Models;

namespace ProjetoLaboratorio.Models
{
    public class FinanceiroModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo SolicitacaoId é obrigatório.")]
        [Display(Name = "Pedidos:")]
        public int PedidosId { get; set; }
        public PedidosModel Pedidos { get; set; }
        public ClientesModel Clientes { get; set; }

        [Display(Name = "Valor Total:")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        public float ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo Forma de Pagamento é obrigatório.")]
        [Display(Name = "Forma de Pagamento:")]
        public string FormaPagamento { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "O campo Finalizado é obrigatório.")]
        [Display(Name = "Finalizado:")]
        public string Finalizado { get; set; }
    }

}
