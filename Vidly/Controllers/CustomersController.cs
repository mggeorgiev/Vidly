using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using Vidly.Models;
using PagedList;

using Vidly.ViewModels;
using System;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        //initialize db context
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //dispose the object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        
        [HttpPost] //do not alow to be called from the get method
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Id = customer.Id;
                customerInDB.Name = customer.Name;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index(string discountRate, string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SortOrder = sortOrder;

            var discountRateLst = new List<string>();

            var discountRateQry = from m in _context.MembershipTypes
                           orderby m.Name
                           select m.Name;

            discountRateLst.AddRange(discountRateQry.Distinct());


            ViewBag.discountRate = new SelectList(discountRateLst);

            //defered execution - executed during iteration over the customers object
            //var customers = _context.Customers;

            //imediate execution
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var customers = (from c in _context.Customers
                             join m in _context.MembershipTypes on c.MembershipTypeId equals m.Id
                             select c).Include("MembershipType");


            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                customers = customers.Where(c => c.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(discountRate))
            {
                customers = customers.Where(c => c.MembershipType.Name.Contains(discountRate));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.Name);
                    break;
                case "Date":
                    customers = customers.OrderBy(c => c.DateOfBirth);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(c => c.DateOfBirth);
                    break;
                default:
                    customers = customers.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}