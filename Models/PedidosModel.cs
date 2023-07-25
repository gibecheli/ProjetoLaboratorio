using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class PedidosModel
    {
        [Key]
        [Display(Name = "ID: ")]
        public int PedidoId { get; set; }

        [Display(Name = "Cliente: ")]
        public ClientesModel ClientesModel { get; set; }
        [ForeignKey("Cliente")]
        public int ClientesModelId { get; set; }

        [Display(Name = "Solicitante: ")]
        public SolicitanteModel SolicitanteModel { get; set; }
        [ForeignKey("Solicitante")]
        public int SolicitanteModelId { get; set; }

        [Display(Name = "Analises: ")]
        public AnalisesModel AnalisesModel { get; set; }
        [ForeignKey("Analise")]
        public int AnalisesModelId { get; set; }

        [Display(Name = "Tipo de Análise: ")]
        public TipoAnalisesModel TipoAnalisesModel {get; set; }
        [ForeignKey("TipoAnalises")]
        public int TipoAnalisesModelId { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }
        
        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public virtual float total
        {
            get
            {
                return quantidade * valor;

            }
        }

        [Display(Name = "Data de Entrada: ")]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        [Display(Name = "Data de Saída: ")]
        public DateTime DataSaida { get; set; }


        public ICollection<ResultadoModel> Resultado { get; set; }
    }
}
