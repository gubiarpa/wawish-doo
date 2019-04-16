using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using wawishapp.Models;
using wawishapp.Controllers.Base;
using wawishapp.ViewModels;

namespace wawishapp.Controllers
{
    public class CustomersController : BasicController
    {
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();            
            return View(customers);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);

            if (customer == null)
                return RedirectToAction("New");

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(CustomerFormViewModel customerFormViewModel)
        {
            var customerSelected = _context.Customers.Single(c => c.Id == customerFormViewModel.Customer.Id);
            customerSelected.AssignMe(customerFormViewModel.Customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            if (Id > 0)
            {
                var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == Id);

                if (customer == null)
                    return new EmptyResult();

                return View(customer);
            }
            return new HttpNotFoundResult();
        }
    }
}