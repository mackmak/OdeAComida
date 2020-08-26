using OdeAComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Configuration;

namespace OdeAComida.Controllers
{
    public class HomeController : Controller
    {
        IOdeAComidaDb _bd;

        public HomeController()
        {
            _bd = new OdeAComidaDb();
        }

        public HomeController(IOdeAComidaDb bd)
        {
            _bd = bd;
        }

        public ActionResult AutoComplete(string term)//para o autocompletar do API do jaquery funcionar, o parâmetro precisa ser "term"
        {
            var model = _bd.Query<Restaurante>().Where(r => r.Nome.StartsWith(term)).
                Take(10).Select(r => new { label = r.Nome });//o jquery especifica que o retorno deve ter uma propriedade label, value ou ambos

            return Json(model, JsonRequestBehavior.AllowGet);//o retorno deve ser formatado para json
        }


        [RequireHttps]
        [OutputCache(Duration = 60)]
        public ActionResult Index(string term = null, int page = 1)
        {
            /*var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = String.Format("{0}::{1} {2}", controller, action, id);*/

            ViewBag.Message = OdeAComida.Views.Home.Resources.Saudacao;

            var model = _bd.Query<Restaurante>().OrderByDescending(r => r.Analises.Average(a => a.Nota)).
                Select(r => new ListViewModelRestaurante
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Cidade = r.Cidade,
                    Pais = r.Pais,
                    QtdAnalises = r.Analises.Count
                }).Where(r => term == null || r.Nome.StartsWith(term)).ToPagedList(page, 10);

            ViewBag.Something = ConfigurationManager.AppSettings["Something"];

            //bloco verificando se é uma requisição ajax, para remontar o formuário
            if (Request.IsAjaxRequest())
                return PartialView("_Restaurantes", model);

            return View(model);
        }

        [Authorize]
        public ActionResult About()
        {
            var objeto = new AboutModel();
            objeto.Nome = "Marcos";
            objeto.Localizacao = "Casa";

            return View(objeto);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Disposable turns it able to be on a "using" block construction
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_bd != null)
            {
                _bd.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
