using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeAComida.Models
{
    public class AnaliseRestaurante:IValidatableObject
    {
        public int Id { get; set; }
        [Range(1,10, ErrorMessage="Fora do tamanho desejado")]

        public int Nota { get; set; }
        [Required]
        [StringLength(1024)]
        public string Corpo { get; set; }
        
        [StringLength(80)]
        [Display(Name="Nome do Analista")]
        [DisplayFormat(NullDisplayText="Anônimo")]
        [AtributoMaxPalavras(5)]
        public string NomeAnalista { get; set; }
        public int RestauranteId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nota < 2 && NomeAnalista.ToLower().StartsWith("sérgio"))
            {
                yield return new ValidationResult("Faz isso não, rapá.");
            }
        }
    }
}