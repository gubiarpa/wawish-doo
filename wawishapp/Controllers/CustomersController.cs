using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using wawishapp.Models;

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
    }
}