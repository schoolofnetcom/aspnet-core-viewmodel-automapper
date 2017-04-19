using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.PessoaViewModels;

namespace WebCore.Controllers
{
    [Route("Publish")]
    public class PessoaController : Controller
    {
        [Route("")]
        [Route("Coisa")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("DiferenteP")]
        public IActionResult Diferente()
        {
            Pessoa p = new Pessoa();
            p.Nome = "Joao";
            p.DataNascimento = DateTime.Now.AddYears(-20);

            return View(p);
        }

        [Route("TesteP")]
        public IActionResult Teste()
        {
            return View("Index");
        }

        [Route("ViewModelP")]
        public IActionResult ViewModel(int? id)
        {
            Pessoa p = new Pessoa();
            p.Nome = "Joao";
            p.DataNascimento = DateTime.Now.AddYears(-20);

            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(p);

            return View("Carrega", lista);
        }
    }
}