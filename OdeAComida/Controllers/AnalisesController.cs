using OdeAComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeAComida.Controllers
{
    public class AnalisesController : Controller
    {
        OdeAComidaDb _db = new OdeAComidaDb();

        public ActionResult MelhorAnalise()
        {
            var maiorNota = _db.Analises.OrderByDescending(a => a.Nota).FirstOrDefault();

            return PartialView("_Analises", maiorNota);
        }
        public ActionResult Index([Bind(Prefix="id")]int restauranteId)
            //atrela tudo com o prefixo "id" à variável restauranteId
            //diz ao modelbinder para, ao buscar pelo restauranteId, procurar por "id"
        {
            var restaurante = _db.Restaurantes.Find(restauranteId);

            if (restaurante != null)
            {
                return View(restaurante);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Criar(int restauranteId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(AnaliseRestaurante analise)
        {
            if (ModelState.IsValid)
            {
                _db.Analises.Add(analise);
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = analise.RestauranteId});
            }

            return View(analise);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var model = _db.Analises.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AnaliseRestaurante analise)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(analise).State = System.Data.Entity.EntityState.Modified;//System.Data.EntityState.Modified;//A API Entry é uma forma de dizer ao EF para rastrear o objeto do parâmetro (análise), visando a futura alteração na base
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = analise.RestauranteId });
            }

            return View(analise);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}