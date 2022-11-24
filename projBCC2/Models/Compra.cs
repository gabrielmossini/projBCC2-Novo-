using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projBCC2.Models
{
    [Table("Compras")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }


        [Display(Name = "Funcionario: ")]
        public Funcionario? funcionario { get; set; }
        [Display(Name = "Funcionario: ")]
        public int funcionarioid { get; set; }


        [Display(Name = "Empresa: ")]
        public Empresa? empresa { get; set; }
        [Display(Name = "Empresa: ")]
        public int empresaid { get; set; }


        [StringLength(40)]
        [Required(ErrorMessage = "Campo PRODUTO é obrigatorio...")]
        [Display(Name = "Produto: ")]
        public string? produto { get; set; }


        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime data { get; set; }


        [Required(ErrorMessage = "Campo QUANTIDADE é obrigatorio...")]
        [Display(Name = "Quantidade: ")]
        public int quantidadeCompra { get; set; }


        [DisplayFormat(DataFormatString = "R$ {0:N2}")]
        [Display(Name = "Valor (Unidade)")]
        public float valorUN { get; set; }


        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total
        {
            get
            {
                return quantidadeCompra * valorUN;
            }
        }
    }
}
