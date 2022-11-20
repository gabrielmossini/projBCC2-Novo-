using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Xml.Linq;

namespace projBCC2.Models
{
    public enum Operacao { Compra, Venda }
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Conta é obrigatório...")]
        [Display(Name = "Conta: ")]
        public Conta conta { get; set; }
        [ForeignKey("Conta")]
        public int contaid { get; set; }

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime data { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }
        
        [Display(Name = "Operação: ")]
        public Operacao operacao { get; set; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total
        {
            get
            {
                return quantidade * valor;
            }
        }

        [Display(Name = "Operação: ")]
        [NotMapped]
        public virtual string tipoOperacao
        {
            get { return (operacao == Operacao.Compra ? "Compra" : "Venda"); }
        }
    }
}
