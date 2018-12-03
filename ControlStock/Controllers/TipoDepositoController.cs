using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlStock.Controllers
{
    public class TipoDepositoController : Controller
    {
        // GET: TipoDeposito
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoDeposito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDeposito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeposito/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeposito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDeposito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeposito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDeposito/Delete/5
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