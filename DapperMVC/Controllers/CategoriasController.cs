using System;
using System.Web.Mvc;
using DapperMVC.Models.Interfaces.Repository;
using DapperMVC.Models.Repository;
using Entidades.Entities;

namespace DapperMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = _categoriaRepository.GetTodos();
            return View(categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(Guid id)
        {
            var categoria = _categoriaRepository.GetPorId(id);
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                // TODO: Add insert logic here
                _categoriaRepository.Adicionar(categoria);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(Guid id)
        {
            var categoria = _categoriaRepository.GetPorId(id);
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                // TODO: Add update logic here
                _categoriaRepository.Editar(categoria);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(Guid id)
        {
            var categoria = _categoriaRepository.GetPorId(id);
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            try
            {
                // TODO: Add delete logic here
                _categoriaRepository.Remover(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}