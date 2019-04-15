using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using wawishapp.Models;
using wawishapp.Controllers.Base;

namespace wawishapp.Controllers
{
    public class CustomersController : BasicController
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();            
            return View(customers);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            if (Id > 0)
            {
                var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

                if (customer == null)
                    return new EmptyResult();

                return View(customer);
            }
            return new HttpNotFoundResult();
        }
    }
}