using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class StockValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if(movie.Cuntity==0||movie.Cuntity>20)
                return new ValidationResult("The fild Number in Stock must be betwen 1 and 20");
            else
                return ValidationResult.Success;
        }
    }
}