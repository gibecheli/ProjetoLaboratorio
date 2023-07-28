using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ProjetoLaboratorio.Models
{
    [Table("Analises")]
    public class AnaliseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        public ICollection<TipoAnaliseModel> TiposAnalise { get; set; }
        public ICollection<PedidoModel> Pedidos { get; set; }
    }
}
