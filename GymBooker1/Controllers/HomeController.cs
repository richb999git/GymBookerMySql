using GymBooker1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymBooker1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.GymClasses = db.GymClasses.ToList();
            
            ViewBag.cardioDesc = CategoryDescs.GetCategoryDescs()[0];
            ViewBag.toneDesc = CategoryDescs.GetCategoryDescs()[1];
            ViewBag.mindBodyDesc = CategoryDescs.GetCategoryDescs()[2]; 
            ViewBag.strengthDesc = CategoryDescs.GetCategoryDescs()[3];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}