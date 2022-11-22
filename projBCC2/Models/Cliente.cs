using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projBCC2.Models
{
    public enum Estado { AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO }
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo NOME é obrigatorio...")]
        [Display(Name = "Nome: ")]
        [StringLength(40)]
        public string? nome { get; set; }

        [Display(Name = "Idade: ")]
        [Range(18, 70, ErrorMessage = "Insira uma idade entre 18 - 70")]
        public int idade { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatorio...")]
        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo CIDADE é obrigatorio...")]
        [Display(Name = "Cidade: ")]
        public string? cidade { get; set; }

        //public ICollection<Conta> contas { get; set; }

    }
}
