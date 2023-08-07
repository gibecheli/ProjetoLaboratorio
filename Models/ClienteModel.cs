using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLaboratorio.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        [Display(Name = "CPF/CNPJ")]
        [StringLength(18, ErrorMessage = "O campo CPF/CNPJ deve ter {1} caracteres.", MinimumLength = 14)]
        public string CpfCnpjC { get; set; }

        
        [Required(ErrorMessage = "O campo Tipo Pessoa é obrigatório.")]
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoaEnum TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [Display(Name = "Estado")]
        public EstadoEnum Estado { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(14, ErrorMessage = "O campo Telefone deve ter no máximo {1} caracteres.")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [StringLength(15, ErrorMessage = "O campo Celular deve ter no máximo {1} caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Email")]                
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Display(Name = "Inscrição Estadual ou RG")]
        public string? InscEstRG { get; set; }

        [Required(ErrorMessage = "O campo Nome Propriedade é obrigatório.")]
        [Display(Name = "Nome Propriedade")]
        public string NomePropriedade { get; set; }

        [Required(ErrorMessage = "Informe se o cliente tem algum convênio.")]
        [Display(Name = "Convênio")]
        public int? ConvenioId { get; set; }
        public ConvenioModel Convenio { get; set; }

        [Display(Name = "Data do Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<ConvenioModel> Convenios { get; set; }
    }

    public enum TipoPessoaEnum
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica,

        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica
    }

    public enum EstadoEnum
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO
    }

 
}
