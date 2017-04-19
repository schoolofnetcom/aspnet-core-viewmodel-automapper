using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.ViewModels
{
    public class BlogViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Título é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Limite do campo é 100 caracteres.")]
        public string Tilulo { get; set; }

        [Required(ErrorMessage = "Resumo é obrigatório!")]
        [MaxLength(300)]
        public string Resumo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Url { get; set; }

        [MaxLength(60)]
        public string Autor { get; set; }

        [Required]
        public string Captcha { get; set; }
    }
}
