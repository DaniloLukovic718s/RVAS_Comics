using RVAS_Stripovi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RVAS_Stripovi.ViewModel;

namespace RVAS_Stripovi.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var customers = _context.Customers.ToList();
            var comicBooks = _context.ComicBooks.ToList();

            var viewModel = new RentalFormViewModel()
            {
                Rental = new Rental(),
                Customers = customers,
                ComicBooks = comicBooks
            };

            return View("RentalForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(Rental rental)
        {
            var customerRental = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);
            var comicBookRental = _context.ComicBooks.SingleOrDefault(c => c.Id == rental.ComicBookId);

            if (!ModelState.IsValid)
            {

                var customers = _context.Customers.ToList();
                var comicBooks = _context.ComicBooks.ToList();


                var viewModel = new RentalFormViewModel
                {
                    
                    Customers = customers,
                    ComicBooks = comicBooks,
                    Rental = new Rental()
                };
                return View("RentalForm", viewModel);
            }

            if (rental.Id == 0)
            {
                _context.Rentals.Add(rental);
                customerRental.Rentals.Add(rental);
                comicBookRental.Rentals.Add(rental);
            }

            else
            {
                var RentalExists = _context.Rentals.Single(r => r.Id == rental.Id);
                RentalExists.ComicBookId = rental.ComicBookId;
                RentalExists.CustomerId = rental.CustomerId;
                RentalExists.DateRented = rental.DateRented;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Rentals");

        }



        // GET: Rentals
        public ActionResult Index()
        {
            
            var rentals = _context.Rentals.Include(r => r.ComicBook.Genre).Include(r => r.Customer).ToList();
            if (User.IsInRole(RoleName.Administrator))
            {
                return View("Index", rentals);
            }
            else
            {
                return View("IndexReadOnly", rentals);
            }
        }
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Details(int id)
        {
            var rental = _context.Rentals.Include(r => r.ComicBook.Genre).Include(r => r.Customer).SingleOrDefault(c => c.Id == id);

            if (rental == null)
            {
                return HttpNotFound();
            }

            return View(rental);
        }
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(Rental rental)
        {
            var deleteRental = _context.Rentals.SingleOrDefault(c => c.Id == rental.Id);
            _context.Rentals.Remove(deleteRental);
            _context.SaveChanges();

            return RedirectToAction("Index", "Rentals");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rental == null)
                return HttpNotFound();

            var viewModel = new RentalFormViewModel
            {
                Rental = rental,
                ComicBooks = _context.ComicBooks.ToList(),
                Customers = _context.Customers.ToList()
            };

            return View("RentalForm", viewModel);
        }

        //public ActionResult DueDateSelect (int id)
        //{
        //    var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);
        //    if (rental == null)
        //    {              
        //        return HttpNotFound();  
        //    }
        //    return View(rental);

        //}
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult AddDueDate (int id)
        {

            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

            rental.DueDate = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index", "Rentals");
        }
    }
}