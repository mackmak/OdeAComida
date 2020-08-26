using OdeAComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeAComida.Tests.Caracteristicas
{
    public interface IAlgoritmoAvaliacao
    {

        ResultadoNota Calcular(IList<AnaliseRestaurante> reviews);
    }

    public class SimpleRatingAlgorithm : IAlgoritmoAvaliacao
    {
        public ResultadoNota Calcular(IList<AnaliseRestaurante> reviews)
        {
            var result = new ResultadoNota();
            result.Nota = (int)reviews.Average(r => r.Nota);
            return result;
        }
    }

    public class WeightedRatingAlgorithm : IAlgoritmoAvaliacao
    {
        public ResultadoNota Calcular(IList<AnaliseRestaurante> reviews)
        {
            var result = new ResultadoNota();
            var counter = 0;
            var total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Nota * 2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Nota;
                }
            }

            result.Nota = total / counter;
            return result;
        }
    }

}
