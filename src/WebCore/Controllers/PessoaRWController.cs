using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.PessoaViewModels;

namespace WebCore.Controllers
{
    public class PessoaRWController : Controller
    {
        // GET: PessoaRW
        public ActionResult Index()
        {
            return View();
        }

        // GET: PessoaRW/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaRW/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaRW/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaRW/Edit/5
        public ActionResult Edit(int id)
        {
            //Obtem objeto pelo parametro id
            //Envia o objeto para edição na View

            Pessoa p = new Pessoa();
            p.Nome = string.Format("Joao (id = {0})", id);
            p.DataNascimento = new DateTime(1990, 5, 5);

            return View(p);
        }

        // POST: PessoaRW/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //public ActionResult Edit(int id, Pessoa p)
        //public ActionResult Edit(int id, [Bind("Nome,DataNascimento")] Pessoa p) //Erro no IsValid
        public ActionResult Edit(Pessoa p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    p.IsEstudante = true; //resultado de outro método

                    if (TryValidateModel(p))
                    {
                        //Salvar();
                    }
                }
                else
                    return View(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaRW/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaRW/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}