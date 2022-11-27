using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projBCC2.Models
{
    public enum Funcao { COMPRAS, FINANÇAS, REGISTRO, TI, RECEPÇÃO, PESSOAL, TESOURARIA, ENGENHARIA, SEGURANÇA, MOTORISTA, ADMINISTRAÇÃO}
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo NOME é obrigatorio...")]
        [Display(Name = "Nome: ")]
        [StringLength(40)]
        public string? nomeFuncionarios { get; set; }

        [Display(Name = "Idade: ")]
        [Range(18, 75, ErrorMessage = "Insira uma idade entre 18 - 75")]
        public int idade { get; set; }

        [Required(ErrorMessage = "Campo FUNÇÃO é obrigatorio...")]
        [Display(Name = "Função: ")]
        public Funcao funcao { get; set; }

        //public ICollection<Conta> contas { get; set; }
    }
}
