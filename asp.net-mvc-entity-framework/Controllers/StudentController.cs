using asp.net_mvc_entity_framework.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_mvc_entity_framework.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new Entities1();
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() {
            var db = new Entities1();
            ViewBag.Depts = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student) {
            var db = new Entities1();
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        
        }
    }
}