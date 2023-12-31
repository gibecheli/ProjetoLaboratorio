﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLaboratorio.Models
{
    [Table("Pedidos")]
    public class PedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "O campo ClienteId é obrigatório.")]
        [Display(Name = "Cliente")]
        public string CpfCnpjC { get; set; }
        public ClienteModel Cliente { get; set; }

        [Required(ErrorMessage = "O campo SolicitanteId é obrigatório.")]
        [Display(Name = "Solicitante")]
        public string CpfCnpjS { get; set; }
        public SolicitanteModel Solicitante { get; set; }   

        [Required(ErrorMessage = "O campo AnaliseId é obrigatório.")]
        [Display(Name = "Análise")]
        public int AnaliseId { get; set; }
        public AnaliseModel Analise { get; set; }

        [Required(ErrorMessage = "O campo TipoAnaliseId é obrigatório.")]
        [Display(Name = "Tipo de Análise:")]
        public int TipoAnaliseId { get; set; }
        public TipoAnaliseModel TipoAnalise { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }
              
        // Atributos adicionais
        [Display(Name = "Total")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total;
         
        [MaxLength(100, ErrorMessage = "O campo Observacao deve ter no máximo 100 caracteres.")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo Data de Entrada é obrigatório.")]
        [Display(Name = "Data de Entrada:")]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        [Display(Name = "Data de Saída:")]
        public DateTime? DataSaida { get; set; }

        // Coleções para estabelecer os relacionamentos
        public ICollection<ResultadoModel> Resultados { get; set; }
        public ICollection<FinanceiroModel> Financeiros { get; set; }
          
    }
}
