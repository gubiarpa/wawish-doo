﻿using System.Web;
using System.Web.Mvc;

namespace wawishapp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // ◄ ... To authorize an attribute
        }
    }
}
