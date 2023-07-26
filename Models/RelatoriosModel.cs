using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class RelatoriosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Display(Name = "Laudo:")]
        public int ResultadoId { get; set; }
        public ResultadoModel Laudo { get; set; }

        // Atributos para armazenar as informações do relatório
        [Display(Name = "Total de Análises por Período:")]
        public int TotalAnalisesPorPeriodo { get; set; }

        [Display(Name = "Valor do Financeiro por Período:")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float ValorFinanceiroPorPeriodo { get; set; }

        [Display(Name = "Data do Relatório:")]
        public DateTime DataRelatorio { get; set; } = DateTime.Now;
    }
}
