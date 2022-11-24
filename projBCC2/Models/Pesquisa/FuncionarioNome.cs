namespace projBCC2.Models.Pesquisa
{
    public class FuncionarioNome
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public EstadoCliente estadoCliente { get; set; }
    }
}
