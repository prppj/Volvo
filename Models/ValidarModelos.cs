using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volvo.Models
{
    public class ValidarModelos :  ValidationAttribute
    {
        public ValidarModelos(string[] modelosValidos)
        {
            ModelosValidos = modelosValidos.ToList();
        }

        public List<string> ModelosValidos { get; }

        public string GetErrorMessage() => $"Modelo inválido";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var caminhao = (Caminhao)validationContext.ObjectInstance;

            //condition to show error
            if (ModelosValidos.IndexOf(caminhao.Modelo) == -1)
            {
                return new ValidationResult(GetErrorMessage());
            }

            //success
            return ValidationResult.Success;
        }
    }
}
