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

            [Display(Name = "Resultado:")]
            public int ResultadoId { get; set; }
            public ResultadoModel Laudo { get; set; }

        //o que conter no relatorio, quantidade de pedidos, numero de amostras, qtdade por tipo de analise, quantidade por periodo

            [Required(ErrorMessage = "O campo Conteudo é obrigatório.")]
            [Display(Name = "Conteúdo:")]
            public string Conteudo { get; set; }

            [Display(Name = "Data do Relatório:")]
            public DateTime DataRelatorio { get; set; } = DateTime.Now;
    }
}
