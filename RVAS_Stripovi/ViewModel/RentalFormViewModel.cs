using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RVAS_Stripovi.Models;

namespace RVAS_Stripovi.ViewModel
{
    public class RentalFormViewModel
    {
        public List<ComicBook> ComicBooks { get; set; }

        public List<Customer> Customers { get; set; }

        public Rental Rental { get; set; }
    }
}