using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RVAS_Stripovi.Models
{
    public class DateRentedCannotBeFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rental = (Rental)validationContext.ObjectInstance;

            if (rental.DateRented > DateTime.Now)
            {
                return new ValidationResult("You cannot pick a date in the future, please enter a valid date");
            }
            else return ValidationResult.Success;

        }
    }
}