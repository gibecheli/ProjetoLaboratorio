using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace ProjetoLaboratorio.Models
{
    [Table("Relatorios")]
    public class RelatorioModel
    {
        [Key]
        public int Id { get; set; }

        // Atributos para armazenar as informações do relatório
        [Display(Name = "Total de Análises por Período:")]
        public int TotalAnalisesPorPeriodo { get; set; }

        [Display(Name = "Valor do Financeiro por Período:")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorFinanceiroPorPeriodo { get; set; }

        [Display(Name = "Data do Relatório:")]
        public DateTime DataRelatorio { get; set; } = DateTime.Now;

        // Método que calcula o relatório com base nos pedidos
        public static RelatorioModel CalcularRelatorio(IEnumerable<PedidoModel> listaDePedidos)
        {
            // Cálculo do total de análises por período
            int totalAnalisesPorPeriodo = (int)listaDePedidos.Sum(pedido => pedido.Quantidade);

            // Cálculo do valor financeiro por período
            decimal valorFinanceiroPorPeriodo = listaDePedidos.Sum(pedido => pedido.Valor);

            // Crie o objeto do relatório com os dados calculados
            var relatorio = new RelatorioModel
            {
                TotalAnalisesPorPeriodo = totalAnalisesPorPeriodo,
                ValorFinanceiroPorPeriodo = valorFinanceiroPorPeriodo
            };

            return relatorio;
        }
    }

    public class QuantidadePorTipoAnalise
    {
        public int TipoAnaliseId { get; set; }
        public string NomeTipoAnalise { get; set; }
        public int Quantidade { get; set; }
    }
}
