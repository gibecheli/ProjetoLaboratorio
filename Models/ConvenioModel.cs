using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace ProjetoLaboratorio.Models
{
    [Table("Convenios")]
    public class ConvenioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a porcentagem de desconto")]
        [Display(Name = "Desconto:")]
        public float Desconto { get; set; }
    }
}
