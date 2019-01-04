using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Name="John Smith", Id=1},
                new Customer { Name="Mary Williams", Id=2}
            };

            var viewModel = new CustomersViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int? Id)
        {
            var customer = new Customer();

            switch (Id)
            {
                case 1:
                    customer.Name = "John Smith";
                    break;
                case 2:
                    customer.Name = "Mary Williams";
                    break;
                default:
                    customer.Name = "Error";
                    break;
            }
            return View(customer);
        }
    }
}