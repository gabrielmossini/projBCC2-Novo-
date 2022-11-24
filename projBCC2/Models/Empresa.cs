using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace projBCC2.Models
{
    public enum EstadoEmpresa { AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO }
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome EMPRESA é obrigatorio...")]
        [Display(Name = "Nome: ")]
        [StringLength(40)]
        public string? nomeEmpresa { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatorio...")]
        [Display(Name = "Estado: ")]
        public EstadoEmpresa estadoEmpresa { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo CIDADE é obrigatorio...")]
        [Display(Name = "Cidade: ")]
        public string? cidade { get; set; }

        //public ICollection<Conta> contas { get; set; }

    }
}
