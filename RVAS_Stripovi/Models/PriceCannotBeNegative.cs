using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.Models
{
    public class PriceCannotBeNegative : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comic = (ComicBook)validationContext.ObjectInstance;

            if (comic.Price < 0)
            {
                return new ValidationResult("Price must be positive!");
            }

            if (comic.Price == 0)
            {
                return new ValidationResult("Price cannot be 0");
            }

            else return ValidationResult.Success;

        }
    }
}
