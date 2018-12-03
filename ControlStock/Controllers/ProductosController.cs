using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStock.DAL;
using ControlStock.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlStock.Controllers
{
    public class ProductosController : Controller
    {
        protected readonly IProductoRepository repo;

        public ProductosController(IProductoRepository _repo)
        {
            this.repo = _repo;

        }
        // GET: Productos
        public ActionResult Index()
        {

            return View(repo.Grilla());
        }
        public ActionResult Grilla(string filter = null, int page = 1,
           int pageSize = 5, string sort = "Nombre", string sortdir = "ASC")
        {
            var ret = repo.PageGrid(pageSize, page, filter, sort, sortdir);
            ViewBag.filter = filter;


            return View(ret);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View(repo.Get_Edicion(null));
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoEdicionVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Add(vm.Edicion);
                repo.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.Get_Edicion(id));
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoEdicionVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Add(vm.Edicion);
                repo.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}