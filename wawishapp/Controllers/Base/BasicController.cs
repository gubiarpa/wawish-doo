using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wawishapp.Models;

namespace wawishapp.Controllers.Base
{
    public abstract class BasicController : Controller
    {
        protected ApplicationDbContext _context;

        public BasicController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}