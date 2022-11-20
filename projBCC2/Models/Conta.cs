using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projBCC2.Models
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente clientes { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteid { get; set; }

        [Display(Name = "Produto: ")]
        public Produto produtos { get; set; }
        [Display(Name = "Produto: ")]
        public int produtoid { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        //public ICollection<Transacao> transacoes { get; set; }
    }
}
