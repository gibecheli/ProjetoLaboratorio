using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class TipoAnalisesModel
    {
        [Key]
        public int TipoId { get; set; }

        public string Descricao { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }
    }

}