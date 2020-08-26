using OdeAComida.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeAComida.Controllers
{
   // [Authorize]//requer que o usuário esteja logado
    [AtributoLog]
    public class CuisineController : Controller
    {

        //[Authorize]
        public ActionResult Busca(string nome = "teste")
        {
            throw new Exception("Algo horrível aconteceu");
            //return Content(Server.HtmlEncode(nome));
            //return RedirectPermanent("https://www.microsoft.com/net/");
            //return RedirectToAction("Index", "Home", RouteData.Values);
            //return RedirectToRoute("Default", new { controller="Home", action="About"});
            //return File(Server.MapPath("~/Content/Site.css"), "text/css");
            //return Json(new { Mensagem = msg, Nome = "Marcos" }, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet]
        public ActionResult Busca()
        {
            return Content("Busca");
        }*/

    }
}
