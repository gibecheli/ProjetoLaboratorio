using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class SolicitanteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Pessoa é obrigatório.")]
        public string TipoPessoa { get; set; }

        [Key]
        [Required(ErrorMessage = "Campo CPF ou CNPJ é obrigatório...")]
        [Display(Name = "CPF/CNPJ: ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; }

        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
                       
        [Display(Name = "IE: ")]
        public string? InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string? RazaoSocial { get; set; }

        public DateTime DataDeCadastro { get; set; } = DateTime.Today;
    }
}
