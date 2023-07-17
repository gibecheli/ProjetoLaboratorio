using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoLaboratorio.Models
{
    public enum Estado { AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO };

    public class ClientesModel
    {
        [Key]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Display(Name = "Tipo: ")]
        public string TipoPessoa { get; set; }

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

        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Celular é obrigatório...")]
        [Display(Name = "Celular: ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório...")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [Display(Name = "CPF: ")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo CNPJ é obrigatório...")]
        [Display(Name = "CNPJ: ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo Inscrição Estadual é obrigatório...")]
        [Display(Name = "IE: ")]
        public string IE { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatório...")]
        [Display(Name = "Razao Social: ")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome da Propriedade: ")]
        public string NomePropriedade { get; set; }

        [Display(Name = "Data do Cadastro: ")]
        public DateTime DataDoCadastro { get; set; } = DateTime.Now;

        public ICollection<PedidosModel> Pedidos { get; set; }

    }
}


