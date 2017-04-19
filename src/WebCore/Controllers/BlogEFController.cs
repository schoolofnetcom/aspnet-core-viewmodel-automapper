using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.Data;
using WebCore.Models.ManageBlog;
using WebCore.Services.Spec;
using WebCore.ViewModels;
using AutoMapper;

namespace WebCore.Controllers
{
    public class BlogEFController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlogService _srv;
        private readonly IMapper _mapper;

        public BlogEFController(ApplicationDbContext context, IBlogService srv, IMapper mapper)
        {
            _context = context;
            _srv = srv;
            _mapper = mapper;
        }

        // GET: BlogEF
        public async Task<IActionResult> Index()
        {
            var lista = _srv.Listar();
            return View(await _context.Blog.ToListAsync());
        }

        // GET: BlogEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: BlogEF/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: BlogEF/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Autor,Resumo,Tilulo,Url")] Blog blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(blog);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blog);
        //}

        // GET: BlogEF/Edit/5

        // POST: BlogEF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogViewModel blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.Captcha == "123987")
                {
                    //Modo Hard
                    //Blog b = new Blog();
                    //b.Autor = blog.Autor;
                    //b.Resumo = blog.Resumo;
                    //b.Tilulo = blog.Tilulo;
                    //b.Url = blog.Url;

                    //Criar o mapeamento
                    //Transformar um objeto em outro
                    //var b = AutoMapper.Mapper.Map<BlogViewModel, Blog>(blog);

                    var b = _mapper.Map<Blog>(blog);

                    _srv.Salvar(b);
                    return RedirectToAction("Index");
                }
                return View(blog);
            }
            return View(blog);
        }


        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(blog);
        //}

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _srv.Obter(id.Value);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: BlogEF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Autor,Resumo,Tilulo,Url")] Blog blog)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: BlogEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: BlogEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.ID == id);
        }
    }
}
