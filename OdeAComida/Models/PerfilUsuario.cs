using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeAComida.Models
{
    [Table("PerfilUsuario")]
    public class PerfilUsuario
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(80)]
        public string NomeUsuario { get; set; }
        [StringLength(80)]
        public string RestauranteFavorito { get; set; }

    }
}