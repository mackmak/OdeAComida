using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OdeAComida.Models
{
    public class ListViewModelRestaurante
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        [DisplayName("País")]
        public string Pais { get; set; }
        public int QtdAnalises { get; set; }

    }
}