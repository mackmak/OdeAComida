using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeAComida.Controllers;
using OdeAComida.Models;
using OdeAComida.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OdeAComida.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var db = new FakeOdeAComidaDb();
            db.AddSet(TesteDados.Restaurantes);

            HomeController controller = new HomeController(db);
            controller.ControllerContext = new FakeControllerContext();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            IEnumerable<ListViewModelRestaurante> model = (IEnumerable<ListViewModelRestaurante>)result.Model;

            // Assert
            Assert.AreEqual(10, model.Count());
            //Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
