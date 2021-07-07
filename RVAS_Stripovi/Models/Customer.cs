using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Name"), MaxLength(50)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Surname"), MaxLength(50)]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Adress"), MaxLength(100)]
        public string Adress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Phone number"), MaxLength(25)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Age")]
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field City"), MaxLength(50)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Email"), MaxLength(50)]
        public string EmailAdress { get; set; }



        public virtual ICollection<Rental> Rentals { get; set; }


    }
}