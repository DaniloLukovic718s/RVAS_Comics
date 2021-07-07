using RVAS_Stripovi.Models;
using RVAS_Stripovi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RVAS_Stripovi.Controllers
{
    public class ComicBooksController : Controller
    {
        // GET: ComicBooks

        private ApplicationDbContext _context;

        public ComicBooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = "Administrator,User")]
        public ActionResult New()
        {

            var genres = _context.Genres.ToList();

            var viewModel = new ComicBookFormViewModel
            {
                ComicBook = new ComicBook(),
                Genres = genres
            };

            return View("ComicBookForm", viewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Save(ComicBook comicBook)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ComicBookFormViewModel
                {
                    ComicBook = comicBook,
                    Genres = _context.Genres.ToList()
                };
                return View("ComicBookForm", viewModel);
            }

            if (comicBook.Id == 0)
            {
                _context.ComicBooks.Add(comicBook);
            }

            else
            {
                var ComicBookExists = _context.ComicBooks.Single(c => c.Id == comicBook.Id);
                ComicBookExists.Name = comicBook.Name;
                ComicBookExists.PageNumber = comicBook.PageNumber;
                ComicBookExists.GenreId = comicBook.GenreId;
                ComicBookExists.Price = comicBook.Price;
                ComicBookExists.Colored = comicBook.Colored;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "ComicBooks");

            

        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var comicBooks = _context.ComicBooks.Include(g => g.Genre).ToList();
            if (User.IsInRole(RoleName.Administrator) || User.IsInRole(RoleName.User))
            {
                return View("Index", comicBooks);
            }
            else
            {
                return View("IndexReadOnly",comicBooks);
            }

        }



        [Authorize(Roles = "Administrator,User")]
        public ActionResult Details(int id)
        {
            var comicBook = _context.ComicBooks.Include(g => g.Genre).SingleOrDefault(c => c.Id == id);

            if (comicBook == null)
            {
                return HttpNotFound();
            }

            return View(comicBook);
        }

        [Authorize(Roles = "Administrator,User")]
        public ActionResult Delete (ComicBook comicBook)
        {
            var deleteComicBook = _context.ComicBooks.SingleOrDefault(c => c.Id == comicBook.Id);
            _context.ComicBooks.Remove(deleteComicBook);
            _context.SaveChanges();

            return RedirectToAction("Index", "ComicBooks");
        }

        [Authorize(Roles = "Administrator,User")]
        public ActionResult Edit(int id)
        {
            var comicBook = _context.ComicBooks.SingleOrDefault(c => c.Id == id);

            if (comicBook == null)
                return HttpNotFound();

            var viewModel = new ComicBookFormViewModel
            {
                ComicBook = comicBook,
                Genres = _context.Genres.ToList()
            };

            return View("ComicBookForm", viewModel);
        }
    }
}