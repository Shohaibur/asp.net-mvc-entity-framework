using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_mvc_entity_framework.Controllers;
using asp.net_mvc_entity_framework.EF;

namespace asp.net_mvc_entity_framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Entities();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department d)
        {
            var db = new Entities();
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new Entities();
            var data = (from d in db.Departments
                        where d.Id == id
                        select d).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            var db = new Entities();
            var data =(from dp in db.Departments
                       where dp.Name.Equals(d.Name)
                       select dp).SingleOrDefault();
            var exdata = db.Departments.Find(d.Id);
           // db.Departments.Remove(exdata);
            exdata.Name = d.Name;
            /*exdata.F1 = d.F1;
            exdata.F2 = d.F2;*/
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}