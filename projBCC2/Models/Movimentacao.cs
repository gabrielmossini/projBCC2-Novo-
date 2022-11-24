using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace projBCC2.Models
{
    [Table("Balancete")]
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Compras: ")]
        public Compra? compras { get; set; }
        [Display(Name = "Compras: ")]
        public int comprastotal { get; set; }

        [Display(Name = "Vendas: ")]
        public Revenda? revenda { get; set; }
        [Display(Name = "Vendas: ")]
        public int revendastotal { get; set; }

        [Display(Name = "Lucro: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total
        {
            get
            {
                return comprastotal - revendastotal;
            }
        }
    }
}
