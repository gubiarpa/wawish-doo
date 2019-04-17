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
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerSelected = _context.Customers.Single(c => c.Id == customer.Id);
                customerSelected.AssignMe(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            _context.SaveChanges();

            return View();
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