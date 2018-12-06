//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  HomeController.cs
//  Purpose:    Create a controller to hold functions for the Home group
//              of views.
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CostLowApp.Controllers
{
    //Controller definition
    public class HomeController : Controller
    {
        //Returns view of home / landing screen
        public ActionResult Index()
        {
            return View();
        }

        //Returns view of about page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Returns view of contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Returns view of management portal with managment actions
        public ActionResult Manage()
        {
            ViewBag.Message = "Management Portal.";
            return View();
        }

        public ActionResult Exist()
        {
            return View();
        }
    }
}