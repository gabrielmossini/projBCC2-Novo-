using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace projBCC2.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo PRODUTO é obrigatorio...")]
        [Display(Name = "Produto: ")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Quantidade é obrigatorio...")]
        [Display(Name = "Quantidade (Estoque): ")]
        public int quantidade { get; set; }

        [DisplayFormat(DataFormatString = "R$ {0:N2}")]
        [Display(Name = "Valor (Unidade)")]
        public float valor { get; set; }

        //public ICollection<Conta> contas { get; set; }
    }
}
