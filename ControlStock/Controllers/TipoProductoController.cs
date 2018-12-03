using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStock.DAL;
using ControlStock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlStock.Controllers
{
    public class TipoProductoController : Controller
    {
        protected readonly IGenericRepository<TipoProducto> repo;
        public TipoProductoController(IGenericRepository<TipoProducto> _repo)
        {
            this.repo = _repo;
        }

        // GET: TipoProducto
        public ActionResult Index()
        {

            return View(repo.GetAll());
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int id)
        {
            TipoProducto model = repo.GetID(id); 

            return View(model);
        }

        // GET: TipoProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoProducto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Add(model);
                repo.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: TipoProducto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoProducto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Update(model);
                repo.save();

                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoProducto/Delete/5
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