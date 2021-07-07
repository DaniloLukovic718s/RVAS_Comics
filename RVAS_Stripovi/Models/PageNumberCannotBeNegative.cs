using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.Models
{
    public class PageNumberCannotBeNegative : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comic = (ComicBook)validationContext.ObjectInstance;

            if (comic.PageNumber < 0)
            {
                return new ValidationResult("Page Number must be positive!");
            }

            if (comic.PageNumber == 0)
            {
                return new ValidationResult("Page Number cannot be 0");
            }

            else return ValidationResult.Success;

        }


    }
}