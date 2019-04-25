using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wawishapp.Models;

namespace wawishapp.Controllers.Base
{
    public abstract class BasicApiController : ApiController
    {
        protected ApplicationDbContext _context;

        public BasicApiController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
