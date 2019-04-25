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
                Customer = new Customer()
                {
                    Id = 0
                },
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Edit(int Id = 0)
        {
            Customer customer;

            // Busca el elemento o devuelve null
            try
            {
                if (Id == 0) throw new Exception();
                customer = _context.Customers.Single(c => c.Id == Id);
            }
            catch
            {
                customer = null;
            }

            // Redirige a "New" o carga "Edit" con el elemento.
            if (customer == null)
                return RedirectToAction("New");
            else
                return View(new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                });            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Edit", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer); // Insert
            else
                _context.Customers.Single(c => c.Id == customer.Id).AssignMe(customer);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}