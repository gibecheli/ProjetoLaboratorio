using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public class ClientesModel
    {
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Display(Name = "Tipo: ")]
        public string TipoPessoa { get; set; }

        [Key]
        [Display(Name = "CPF/CNPJ: ")]
        public string CpfCnpj { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Campo cidade é obrigatório...")]
        [Display(Name = "Cidade: ")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; }

        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Celular é obrigatório...")]
        [Display(Name = "Celular: ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório...")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
               
        [Display(Name = "IE: ")]
        public string? InscricaoEstadual { get; set; }

        [Display(Name = "Razao Social: ")]
        public string? RazaoSocial { get; set; }

        [Display(Name = "Nome da Propriedade: ")]
        public string NomePropriedade { get; set; }

        [Display(Name = "Data do Cadastro: ")]
        public DateTime DataDoCadastro { get; set; } = DateTime.Today;

        public ICollection<PedidosModel> Pedidos { get; set; }

    }
}


