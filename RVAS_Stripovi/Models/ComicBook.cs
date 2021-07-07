using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.Models
{
    public class ComicBook
    {


        public ComicBook()
        {
            Rentals = new List<Rental>();
        }


        [Key]
        [Required]
        public int Id { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Name"), MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Page Number")]
        [Display(Name ="Page Number")]
        [PageNumberCannotBeNegative]
        public int PageNumber { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill in the data for the field Price")]
        [PriceCannotBeNegative]
        public float Price { get; set; }

        [Required]
        public bool Colored { get; set; }

    }
}