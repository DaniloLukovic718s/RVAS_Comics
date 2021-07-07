using RVAS_Stripovi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS_Stripovi.ViewModel
{
    public class ComicBookFormViewModel
    {

        public ComicBook ComicBook { get; set; }

        public List<Genre> Genres { get; set; }

    }
}