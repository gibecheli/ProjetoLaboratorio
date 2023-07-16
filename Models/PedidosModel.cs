using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class PedidosModel
    {
        [Key]
        [Display(Name = "ID: ")]
        public int PedidoId { get; set; }

        public int ClientesModelId { get; set; }
        public ClientesModel ClientesModel { get; set; }

        public int AnalisesModelId { get; set; }
        public AnalisesModel AnalisesModel { get; set; }

        [Display(Name = "Tipo de Análise: ")]
        public string TipoAnalise { get; set; }

        public float Quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        [Display(Name = "Data de Entrada: ")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data de Saída: ")]
        public DateTime DataSaida { get; set; }

        public ICollection<LaudosModel> Laudos { get; set; }
    }
}
