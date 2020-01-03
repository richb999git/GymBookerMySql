using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymBooker1.Controllers;
using GymBooker1.Models;

namespace GymBooker1.Views
{
    public class GymClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GymCategories/Category/{category}
        public ActionResult Categories(string id) // id is actually the name of the category.
        {
            if (id == null)
            {
                return View("../Home/Index");
            }

            var gymClasses = new List<GymClass>();

            gymClasses = db.GymClasses
                    .Where(d => d.Category == id)
                    .OrderBy(d => d.Category)
                    .ThenBy(d => d.Name).ToList();

            ViewBag.category = id;

            ViewBag.pics = GetPics.GetCategoryPic(ViewBag.category);

            return View(gymClasses.ToList());
        }

        
        // GET: GymClasses/Show/5
        public ActionResult Show(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //GymClass gymClass = db.GymClasses.Find(id);
            var gymClass = db.GymClasses.SingleOrDefault(d => d.Name == id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }

            ViewBag.pics = GetPics.Get2Pics(gymClass.Name);

            return View(gymClass);
        }




        ///////////////////// ADMIN ROUTES TO UPDATE GYM CLASSES. NOT LIKELY TO IMPLEMENT. ////////////////////
        // GENERATED CODE

        // GET: GymClasses
        [Authorize(Roles ="Admin2")]
        public ActionResult Index()
        {
            return View(db.GymClasses.ToList());
        }

        // GET: GymClasses/Details/5
        [Authorize(Roles = "Admin2")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // GET: GymClasses/Create
        [Authorize(Roles = "Admin2")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GymClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin2")]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                db.GymClasses.Add(gymClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gymClass);
        }

        // GET: GymClasses/Edit/5
        [Authorize(Roles = "Admin2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin2")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gymClass);
        }

        // GET: GymClasses/Delete/5
        [Authorize(Roles = "Admin2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin2")]
        public ActionResult DeleteConfirmed(int id)
        {
            GymClass gymClass = db.GymClasses.Find(id);
            db.GymClasses.Remove(gymClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
