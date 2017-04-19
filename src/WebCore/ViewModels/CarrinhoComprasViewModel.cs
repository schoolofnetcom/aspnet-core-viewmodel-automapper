using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Models.Compras;

namespace WebCore.ViewModels
{
    public class CarrinhoComprasViewModel
    {
        public List<Produto> Produtos { get; set; }

        public decimal Total { get; set; }

        public string Mensagem { get; set; }
    }
}
