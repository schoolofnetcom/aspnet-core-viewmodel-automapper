
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Data;
using WebCore.Models.ManageBlog;
using WebCore.Services.Spec;

namespace WebCore.Services.Impl
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Salvar (Incluir ou Atualizar)
        public void Salvar(Blog blog)
        {
            if (blog.ID > 0)
            {
                _context.Blog.Attach(blog);
                _context.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
                _context.Blog.Add(blog);

            _context.SaveChanges();
        }

        //Obter
        public Blog Obter(int id)
        {
            return _context.Blog.SingleOrDefault(b => b.ID == id);
        }
        //Listar
        public IEnumerable<Blog> Listar()
        {
            return _context.Blog.ToList();

        }
        //Deletar
        public void Deletar(int id)
        {
            var b = new Blog() { ID = id }; //_context.Blog.Where(b => b.ID == id).FirstOrDefault();
            _context.Blog.Attach(b);
            _context.Blog.Remove(b);
            _context.SaveChanges();
        }
    }
}
