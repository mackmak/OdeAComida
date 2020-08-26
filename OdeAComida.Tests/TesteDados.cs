using OdeAComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeAComida.Tests
{
    class TesteDados
    {
        public static IQueryable<Restaurante> Restaurantes
        {
            get
            {
                var restaurants = new List<Restaurante>();
                for (int i = 0; i < 100; i++)
                {
                    var restaurant = new Restaurante();
                    restaurant.Analises = new List<AnaliseRestaurante>()
                    {
                        new AnaliseRestaurante { Nota = 4 }
                    };
                    restaurants.Add(restaurant);
                }
                return restaurants.AsQueryable();
            }
        }
    }
}
