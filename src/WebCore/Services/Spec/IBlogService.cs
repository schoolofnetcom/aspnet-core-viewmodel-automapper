using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Models.ManageBlog;

namespace WebCore.Services.Spec
{
    public interface IBlogService
    {
        void Salvar(Blog blog);
        Blog Obter(int id);
        IEnumerable<Blog> Listar();
        void Deletar(int id);
    }
}
