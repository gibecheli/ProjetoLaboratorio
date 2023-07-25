using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class TipoAnalisesModel
    {
        [Key]
        public int TipoId { get; set; }

        [Display(Name = "Tipo de Análise: ")]
        public string TipoAnalises { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }
    }

}