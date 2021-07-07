using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.Models
{
    public class Rental
    {
        [Key]
        [Required]
        public int Id { get; set; }

        
        public virtual ComicBook ComicBook { get; set; }

        [Required]
        [ForeignKey("ComicBook")]
        public int ComicBookId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [DateRentedCannotBeFuture]
        public DateTime DateRented { get; set; }


        
        public DateTime?DueDate { get; set; }

    }
}