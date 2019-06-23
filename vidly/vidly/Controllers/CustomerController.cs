using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer/Index
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            //return new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "cust1" },
            //    new Customer { Id = 2, Name = "cust2" },
            //    new Customer { Id = 3, Name = "cust3" }
            //};

            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public ActionResult Details(int? id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null || id == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}