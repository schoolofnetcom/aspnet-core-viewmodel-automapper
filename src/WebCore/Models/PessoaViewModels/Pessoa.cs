using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models.PessoaViewModels
{
    public class Pessoa
    {
        [Required]
        [BindNever]
        [MaxLength(10, ErrorMessage = "Maximo de 10 cacteres")]
        public string Nome { get; set; }

        [Required]
        [BindRequired]
        [MaxLength(30)]
        public string UltimoNome { get; set; }

        [Required]
        [BindRequired]
        public DateTime DataNascimento { get; set; }

        public bool IsEstudante;

        //[Phone]
        //[EmailAddress]
        //[Url]
        //[CreditCard]
        //[Compare("Propriedade2")]
        //public string Propriedade { get; set; }

        //public string Propriedade2 { get; set; }

        //[Range(0, 100, ErrorMessage ="Valor deve estar entre 0 e 100.")]
        //[RegularExpression("pattern RE")]
        //public decimal Numero { get; set; }
    }
}
