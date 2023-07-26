using ProjetoLaboratorio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class PedidosModel
{
    [Key]
    [Display(Name = "ID: ")]
    public int PedidoId { get; set; }

    [Display(Name = "Cliente: ")]
    public string ClienteId { get; set; }
    public ClientesModel Cliente { get; set; }

    [Display(Name = "Solicitante: ")]
    public string SolicitanteId { get; set; }
    public SolicitanteModel Solicitante { get; set; }

    [Display(Name = "Analises: ")]
    public AnalisesModel Analise { get; set; }
    public int AnaliseId { get; set; }

    [Display(Name = "Tipo de Análise: ")]
    public TipoAnalisesModel TipoAnalise { get; set; }
    public int TipoAnaliseId { get; set; }

    [Display(Name = "Quantidade")]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public float Quantidade { get; set; }

    [Display(Name = "Valor: ")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public float Valor { get; set; }

    [Display(Name = "Total: ")]
    [NotMapped]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public float Total { get; set; }

    [Display(Name = "Data de Entrada: ")]
    public DateTime DataEntrada { get; set; } = DateTime.Now;

    [Display(Name = "Data de Saída: ")]
    public DateTime DataSaida { get; set; }

    public ICollection<ResultadoModel> Resultado { get; set; }
}
