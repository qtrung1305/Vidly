using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        // ctor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // override Dispose

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            //var customers = new List<Customer>
            //{
            //    new Customer {Name = "Trung Vo"},
            //    new Customer {Name = "Van Nguyen"}
            //};

            //var customerViewModel = new CustomerViewModel
            //{
            //    Customers = customers
            //};

            //return View(customerViewModel);

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Trung Vo"},
                new Customer {Name = "Van Nguyen"}
            };

            if (id <= customers.Count)
            {
                return Content(customers[id - 1].Name);
            }
            else
            {
                return Content("Have no Customer with this Id");
            }
        }
    }
}