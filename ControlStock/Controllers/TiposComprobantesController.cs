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
    public class TiposComprobantesController : Controller
    {
        protected readonly IGenericRepository<TipoComprobante> repo;

        public TiposComprobantesController(IGenericRepository<TipoComprobante> _repo)
        {
            this.repo = _repo;

        }
        // GET: TiposComprobantes
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: TiposComprobantes/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetID(id));
        }

        // GET: TiposComprobantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposComprobantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoComprobante model)
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

        // GET: TiposComprobantes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: TiposComprobantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoComprobante model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Update(model);
                repo.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposComprobantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TiposComprobantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoComprobante model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Del(model.TipoComprobanteID);
                repo.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}