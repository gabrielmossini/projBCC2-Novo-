using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace projBCC2.Models
{
    public enum Estado { AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO }
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo NOME é obrigatorio...")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatorio...")]
        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo CIDADE é obrigatorio...")]
        [Display(Name = "Cidade: ")]
        public string cidade { get; set; }
    }
}
