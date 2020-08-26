using System;
using System.Linq;
using OdeAComida.Models;
using System.Collections.Generic;

namespace OdeAComida.Tests.Caracteristicas
{
    internal class Avaliador
    {
        private Restaurante _restaurante;

        public Avaliador(Restaurante restaurante)
        {
            this._restaurante = restaurante;
        }

        public ResultadoNota CalcularNotas(IAlgoritmoAvaliacao algoritmo, int numeroDeAvaliacoes)
        {
            //pega a quantidade desejada de avaliações
            var analisesFiltradas = _restaurante.Analises.Take(numeroDeAvaliacoes);

            return algoritmo.Calcular(analisesFiltradas.ToList());
        }

        /*public ResultadoNota CalcularNotas(int numeroDeAvaliacoes)
        {
            var resultado = new ResultadoNota();
            resultado.Nota = (int)_restaurante.Analises.Average(n => n.Nota);
            return resultado;
        }

        public ResultadoNota CalcularNotasComPeso(int numeroDeAnalises)
        {
            var reviews = _restaurante.Analises.ToArray();
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
    }*/

    }
}