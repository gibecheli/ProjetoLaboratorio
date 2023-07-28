using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public enum StatusPagamento
    {
        [Display(Name = "Em Aberto")]
        EmAberto,

        [Display(Name = "Pago")]
        Pago,

        [Display(Name = "Cancelado")]
        Cancelado
    }

    [Table("Financeiro")]
    public class FinanceiroModel
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo PedidosId é obrigatório.")]
        [Display(Name = "Pedido")]
        public int PedidosId { get; set; }

        public PedidoModel Pedidos { get; set; }
        public ClienteModel Clientes { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo Forma de Pagamento é obrigatório.")]
        [Display(Name = "Forma de Pagamento")]
        public string FormaPagamento { get; set; }

        [Required(ErrorMessage = "O campo Status de Pagamento é obrigatório.")]
        [Display(Name = "Status de Pagamento")]
        public StatusPagamento StatusPagamento { get; set; }
    }
}
