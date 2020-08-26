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
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void Criar_Salvar_Restaurante_Valido()
        {
            // Arrange
            var db = new FakeOdeAComidaDb();
            var controller = new RestauranteController(db);

            controller.Create(new Restaurante());

            // Assert
            Assert.AreEqual(1, db.Added.Count());
            Assert.AreEqual(true, db.Saved);
           
        }

        public void Criar_Nao_Salva_Restanrante_Invalido()
        {

            // Arrange
            var db = new FakeOdeAComidaDb();
            var controller = new RestauranteController(db);
            controller.ModelState.AddModelError("", "Invalid");//simula condição de erro

            controller.Create(new Restaurante());

            // Assert
            Assert.AreEqual(0, db.Added.Count());
        }
    }
}
