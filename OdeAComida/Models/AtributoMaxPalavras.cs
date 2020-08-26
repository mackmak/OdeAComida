using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeAComida.Models
{
    /// <summary>
    /// Classe de validação customizada para verificar o máximo de palavras
    /// </summary>
    public class AtributoMaxPalavras : ValidationAttribute
    {
        private readonly int _maxPalavras;
        public AtributoMaxPalavras(int maximoPalavras)
            : base("{0} tem palavras demais")
        {
            _maxPalavras = maximoPalavras;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string valueString = value.ToString();
                if (valueString.Split(' ').Length > _maxPalavras)
                {
                    var msgErro = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(msgErro);
                }
            }
            return ValidationResult.Success;
        }

    }
}