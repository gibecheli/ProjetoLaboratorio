using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLaboratorio.Models
{
    [Table("TipoAnalises")]
    public class TipoAnaliseModel
    {
        [Key]
        public int TipoAnaliseId { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Análise é obrigatório.")]
        [Display(Name = "Tipo de Análise: ")]
        public string TipoAnalise { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        public ICollection<AnaliseModel> Analises { get; set; }
    }

}