using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLaboratorio.Models
{
    [Table("Solicitantes")]
    public class SolicitanteModel
    {
        [Key]
        [Required(ErrorMessage = "O campo CpfCnpj é obrigatório.")]
        [Display(Name = "CPF/CNPJ")]
        [StringLength(14, ErrorMessage = "O campo CpfCnpj deve ter {1} caracteres.", MinimumLength = 11)]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Tipo Pessoa é obrigatório.")]
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoaEnum TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        [StringLength(100, ErrorMessage = "O campo Endereço deve ter no máximo {1} caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "O campo Cidade deve ter no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [Display(Name = "Estado")]
        [StringLength(2, ErrorMessage = "O campo Estado deve ter {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(14, ErrorMessage = "O campo Telefone deve ter no máximo {1} caracteres.")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [StringLength(15, ErrorMessage = "O campo Celular deve ter no máximo {1} caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "O campo Email deve ter no máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Display(Name = "Data do Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
