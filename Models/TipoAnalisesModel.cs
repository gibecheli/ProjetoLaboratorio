using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class TipoAnalisesModel
    {
        [Key]
        public int TipoId { get; set; }

        [Display(Name = "Tipo de Análise: ")]
        public string TipoAnalise { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        public float valor { get; set; }
    }

}