using Microsoft.AspNetCore.Mvc;
using projBCC2.Models;

namespace projBCC2.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController(Contexto context)
        {
            contexto = context;

        }

        public IActionResult Cliente(string nome)
        {
            List<Cliente> lista = new List<Cliente>();

            if (nome == null) {
                lista = contexto.clientes
                     .OrderBy(o => o.estadoCliente)
                     .ThenBy(p => p.cidade).ThenByDescending(n => n.nome)
                     .ToList();
            }
            else
            {
                lista = contexto.clientes.Where(c => c.nome == nome)
                    .OrderBy(o => o.estadoCliente)
                    .ThenBy(p => p.cidade).ThenByDescending(n => n.nome)
                    .ToList();
            }
            return View(lista);
        }

        public IActionResult Funcionario(string nomeFuncionario)
        {
            List<Funcionario> lista = new List<Funcionario>();

            if (nomeFuncionario == null)
            {
                lista = contexto.funcionarios
                     .OrderBy(o => o.funcao)
                     .ThenBy(p => p.idade).ThenByDescending(n => n.nomeFuncionarios)
                     .ToList();
            }
            else
            {
                lista = contexto.funcionarios.Where(c => c.nomeFuncionarios == nomeFuncionario)
                    .OrderBy(o => o.funcao)
                    .ThenBy(p => p.idade).ThenByDescending(n => n.nomeFuncionarios)
                    .ToList();
            }
            return View(lista);
        }

        public IActionResult Pesquisa()
        {
            return View();
        }


    }
}
