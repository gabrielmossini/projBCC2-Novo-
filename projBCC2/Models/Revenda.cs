using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projBCC2.Models
{
    [Table("Revenda")]
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

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime data { get; set; }

        [Display(Name = "Valor: ")]
        public Compra? compra { get; set; }
        [Display(Name = "Valor: ")]
        public int valorUN { get; set; }

        [Required(ErrorMessage = "Campo QUANTIDADE é obrigatorio...")]
        [Display(Name = "Quantidade: ")]
        public int quantidadeVenda { get; set; }

        [Display(Name = "Estoque: ")]
        public Compra? compras { get; set; }
        [Display(Name = "Estoque: ")]
        public int compraquantidadeCompra { get; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total
        {
            get
            {
                return quantidadeVenda * valorUN;
            }
        }
        [Display(Name = "Estoque: ")]
        [NotMapped]
        public virtual int estoque
        {
            get
            {
                return compraquantidadeCompra - quantidadeVenda;
            }
        }
    }
}
