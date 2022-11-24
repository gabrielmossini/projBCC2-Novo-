using projBCC2.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projBCC2.Models
{
    [Table("Revendas")]
    public class Revenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente? cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteid { get; set; }

        [Display(Name = "Compra: ")]
        public Compra? compra { get; set; }
        [Display(Name = "Compra: ")]
        public int compraid { get; set; }

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Campo QUANTIDADE é obrigatorio...")]
        [Display(Name = "Quantidade: ")]
        public int quantidadeVenda { get; set; }

        /*[Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total
        {
            get
            {
                return quantidadeVenda * compra.valorUN;
            }
        }*/
        [Display(Name = "Estoque: ")]
        [NotMapped]
        public virtual int estoque
        {
            get
            {
                return compra.quantidadeCompra - quantidadeVenda;
            }
        }
    }
}
