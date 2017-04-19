using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.Compras;
using WebCore.ViewModels;

namespace WebCore.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        public IActionResult Index()
        {
            List<Produto> lista = new List<Produto>();

            for (int i = 0; i < 5; i++)
            {
                lista.Add(new Produto() { ID = i, Nome = "Produto " + i, Valor = i * 2.5M });
            }

            var model = new CarrinhoComprasViewModel();
            model.Mensagem = "Parabéns pela compra!";
            model.Produtos = lista;
            model.Total = lista.Sum(p => p.Valor);

            return View(model);
        }
    }
}