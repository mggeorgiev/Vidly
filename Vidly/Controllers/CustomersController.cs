using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Vidly.Models;

using Vidly.ViewModels;

namespace Vidly.Controllers
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

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id=1, Name="John Smith"},
                new Customer { Id=2, Name="Mary Williams"}
            };
        }
    }
}