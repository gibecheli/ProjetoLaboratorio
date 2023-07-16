using System.ComponentModel.DataAnnotations;

namespace ProjetoLaboratorio.Models
{
    public class SolicitanteModel
    {
        [Key]
        public int Id { get; set; }

        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string CNPJ { get; set; }

        public string IE { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; }

        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
    }
}
