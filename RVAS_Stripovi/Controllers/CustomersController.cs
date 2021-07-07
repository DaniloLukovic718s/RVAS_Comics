using RVAS_Stripovi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;


namespace RVAS_Stripovi.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
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

            Customer customer = new Customer();

            return View("CustomerForm", customer);

            
        }

        [Authorize(Roles = RoleName.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {

                var modelCustomer = customer;

                return View("CustomerForm", modelCustomer);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            else
            {
                var CustomerExists = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerExists.Name = customer.Name;
                CustomerExists.Surname = customer.Surname;
                CustomerExists.Adress = customer.Adress;
                CustomerExists.PhoneNumber = customer.PhoneNumber;
                CustomerExists.Age = customer.Age;
                CustomerExists.City = customer.City;
                CustomerExists.EmailAdress = customer.EmailAdress;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");



        }

        // GET: Cutomers
        public ActionResult Index(string sortOrder,string currentFilter, string searchString, int? page)
        {
           

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortPArm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortPArm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "email_asc";
            ViewBag.LNameSortPArm = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "lname_asc";

            if (searchString != null)
            {
                page = 1;
            }

            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            

            var customers = _context.Customers.Include(c => c.Rentals);

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Include(c => c.Rentals).Where(c => c.Name.Contains(searchString) || c.Surname.Contains(searchString) || c.EmailAdress.Contains(searchString) || c.Rentals.Any(r => r.ComicBook.Name.Contains(searchString)));

              
            }


            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.Name);
                    break;
                case "":
                    customers = customers.OrderBy(c => c.Name);
                    break;
                case "email_desc":
                    customers = customers.OrderByDescending(c => c.EmailAdress);
                    break;
                case "email_asc":
                    customers = customers.OrderBy(c => c.EmailAdress);
                    break;
                case "lname_desc":
                    customers = customers.OrderByDescending(c => c.Surname);
                    break;
                case "lname_asc":
                    customers = customers.OrderBy(c => c.Surname);
                    break;

                default:
                    customers = customers.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            


            if (User.IsInRole(RoleName.Administrator))
            {
                return View("Index", customers.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("IndexReadOnly", customers.ToPagedList(pageNumber,pageSize));
            }
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(Customer customer)
        {
            var deleteCustomer = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            _context.Customers.Remove(deleteCustomer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            { 
                return HttpNotFound(); 
            }
            

            return View("CustomerForm", customer);
        }
    }
}