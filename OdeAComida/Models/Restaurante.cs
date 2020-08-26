using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OdeAComida.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        [DisplayName("País")]
        public string Pais { get; set; }
        /// <summary>
        /// virtual faz com que um wrapper seja criado em tempo de execução, 
        /// interceptando as chamadas e assegurando que o carregamento seja feito
        /// </summary>
        public virtual ICollection<AnaliseRestaurante> Analises { get; set; }
    }
}