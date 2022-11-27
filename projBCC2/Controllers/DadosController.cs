using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projBCC2.Models;
using ExcelDataReader;
using System.Text;
using System.Drawing;

namespace projBCC2.Controllers
{
    public class dadosController : Controller
    {
        private readonly Contexto contexto;

        public dadosController(Contexto context)
        {
            contexto = context;

        }

        public IActionResult Cliente()
        {
            contexto.Database.ExecuteSqlRaw("Delete from Clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('clientes', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vCidade = { "Assis", "Candido Mota", "Tarumã", "Paraguaçu Paulista", "Palmital", "Pedrinhas Paulista", "Maracai", "Cruzalia", "Londrina", "Santos", "São Paulo", "Quatá", "PResidente Prudente", "Maringa", "Rancharia", "Itu", "Ourinhos" };
            for (int i = 0; i < 100; i++)
            {
                Cliente cliente = new Cliente();

                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.cidade = vCidade[randNum.Next() % 8];
                cliente.estadoCliente = (EstadoCliente)randNum.Next(27);
                cliente.idade = randNum.Next(18, 75);
                contexto.clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.clientes.OrderBy(o => o.nome).ToList());
        }

        public IActionResult Funcionario()
        {
            contexto.Database.ExecuteSqlRaw("Delete from Funcionarios");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Funcionarios', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            for (int i = 0; i < 100; i++)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.nomeFuncionarios = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2]; ;
                funcionario.funcao = (Funcao)randNum.Next(10);
                funcionario.idade = randNum.Next(18, 62);
                contexto.funcionarios.Add(funcionario);
            }
            contexto.SaveChanges();

            return View(contexto.funcionarios.OrderBy(o => o.nomeFuncionarios).ToList());
        }

        public IActionResult Empresa()
        {
            contexto.Database.ExecuteSqlRaw("Delete from Empresas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Empresas', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeEmpr = { "Empresa de Café", "Empresa de Carro", "Empresa de Bicicleta", "Empresa de Café", "Empresa de Peças", "Empresa de Software", "Empresa de Assistencia Tecnica", "Empresa de Segurança", "Empresa de B.I.", "Empresa Contadorabilidade", "Empresa de Auditoria", "Empresa de Consulta Tributaria", "Empresa de Consulda de Negocios" };
            string[] vCidadeEmpr = { "Assis", "Candido Mota", "Tarumã", "Paraguaçu Paulista", "Palmital", "Pedrinhas Paulista", "Maracai", "Cruzalia", "Londrina", "Santos", "São Paulo", "Quatá", "Presidente Prudente", "Maringa", "Rancharia", "Itu", "Ourinhos" };
            for (int i = 0; i < 100; i++)
            {
                Empresa empresa = new Empresa();

                empresa.nomeEmpresa = vNomeEmpr[randNum.Next() % 13];
                empresa.cidade = vCidadeEmpr[randNum.Next() % 8];
                empresa.estadoEmpresa = (EstadoEmpresa)randNum.Next(27);
                contexto.empresas.Add(empresa);
            }
            contexto.SaveChanges();

            return View(contexto.empresas.OrderBy(o => o.nomeEmpresa).ToList());
        }
    }
}




