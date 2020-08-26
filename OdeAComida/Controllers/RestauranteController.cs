using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeAComida.Models;

namespace OdeAComida.Controllers
{
    public class RestauranteController : Controller
    {
        private IOdeAComidaDb _db;

        public RestauranteController()
        {
            _db = new OdeAComidaDb();
        }

        public RestauranteController(IOdeAComidaDb db)
        {
            _db = db;
        }

        //
        // GET: /Restaurante/

        public ActionResult Index()
        {
            return View(_db.Query<Restaurante>().ToList());
        }


        //
        // GET: /Restaurante/Create

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurante/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public ActionResult Create(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                _db.Add(restaurante);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        //
        // GET: /Restaurante/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurante restaurante = _db.Query<Restaurante>().Single(n => n.Id == id);
            if (TryUpdateModel(restaurante))
            {

            }
            /*if (restaurante == null)
            {
                return HttpNotFound();
            }*/
            return View(restaurante);
        }

        //
        // POST: /Restaurante/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "NomeAnalista")]Restaurante restaurante)
            //aqui, o bind impede que o campo NomeAnalista seja incluido no post, 
            //evitando que o analista seja editado
        {
            if (ModelState.IsValid)
            {
                _db.Update(restaurante);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        //
        // GET: /Restaurante/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurante restaurante = _db.Query<Restaurante>().Single(n => n.Id == id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        //
        // POST: /Restaurante/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = _db.Query<Restaurante>().Single(n => n.Id == id);
            _db.Remove(restaurante);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}