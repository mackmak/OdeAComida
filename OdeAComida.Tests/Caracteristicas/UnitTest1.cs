using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeAComida.Models;
using System.Linq;

// 
// A restaurant's overall rating can be caluclated using various methods.
// For this application we'll want to try different methods over time, 
// but for starters we'll allow an administrator to toggle between two 
// different techniques.
//
// 1. Simple mean of the "rating" value for the most recent n reviews
//    (the admin can configure the value n).
//
// 2. Weighted mean of the last n reviews. The most recent n/2 reviews
//    will be weighted twice as much and the oldest n/2 reviews. 
//
// Overall rating should be a whole number.

namespace OdeAComida.Tests.Caracteristicas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Calcula_Resultado_Para_Uma_Analise()
        {
            var dados = DefinirRestauranteENotas(notas: 4);

            var avaliador = new Avaliador(dados);
            var resultado = avaliador.CalcularNotas(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, resultado.Nota);
        }

        [TestMethod]
        public void Calcula_Resultado_Para_Duas_Analises()
        {
            var dados = DefinirRestauranteENotas(notas: new[] { 4, 8 });

            var avaliador = new Avaliador(dados);
            var resultado = avaliador.CalcularNotas(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, resultado.Nota);
        }

        [TestMethod]
        public void Nota_Inclui_Apenas_Primeiras_N_Analises()
        {
            var dados = DefinirRestauranteENotas(1, 1, 1, 10, 10, 10);

            var avaliador = new Avaliador(dados);
            var resultado = avaliador.CalcularNotas(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, resultado.Nota);
        }

        [TestMethod]
        public void Calcula_Resultado_Para_Duas_Analises_Com_Pesos_Diferentes()
        {
            var dados = DefinirRestauranteENotas(3, 9);

            var avaliador = new Avaliador(dados);
            var resultado = avaliador.CalcularNotas(new WeightedRatingAlgorithm(), 10);

            Assert.AreEqual(5, resultado.Nota);
        }
        
        /// <param name="notas">A palavra chave params permite a entrada de uma quantidade indefinida de valores</param>

        private Restaurante DefinirRestauranteENotas(params int[] notas)
        {
            var restaurante = new Restaurante();

            //agrega as notas definidas no parâmetro para o membro Analises
            restaurante.Analises = notas.Select(n => new AnaliseRestaurante { Nota = n }).ToList();

            return restaurante;
        }
    }
}
