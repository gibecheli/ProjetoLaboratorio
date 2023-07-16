using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class RelatoriosModel
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ID:")]
            public int Id { get; set; }

            [Required(ErrorMessage = "O campo LaudoId é obrigatório.")]
            [Display(Name = "Laudo:")]
            public int LaudoId { get; set; }
            public LaudosModel Laudo { get; set; }

            [Required(ErrorMessage = "O campo Conteudo é obrigatório.")]
            [Display(Name = "Conteúdo:")]
            public string Conteudo { get; set; }

            [Display(Name = "Data do Relatório:")]
            public DateTime DataRelatorio { get; set; } = DateTime.Now;
    }
}
