using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepartmentList()
        {
            var db = new DemoF23_CEntitiesEntities();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department d) {
            var db = new DemoF23_CEntitiesEntities();
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");

        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var db = new DemoF23_CEntitiesEntities();
            var ex = (from d in db.Departments
                     where d.Id == id
                     select d).SingleOrDefault();
            return View(ex);

        }
        [HttpPost]
        public ActionResult Edit(Department d) {
            var db = new DemoF23_CEntitiesEntities();
            var exdata = db.Departments.Find(d.Id);
            exdata.Name = d.Name;
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            var db = new DemoF23_CEntitiesEntities();
            var exdata = db.Departments.Find(id);
            return View(exdata);
        }

        [HttpPost]
        public ActionResult Delete(Department d, string action)
        {
            if (action == "Delete")
            {
                var db = new DemoF23_CEntitiesEntities();
                var exdata = db.Departments.Find(d.Id);
                db.Departments.Remove(exdata);
                db.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            else
            {
                return RedirectToAction("DepartmentList");
            }
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

        public ActionResult StudentList()
        {
            var db = new DemoF23_CEntitiesEntities();
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            var db = new DemoF23_CEntitiesEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("StudentList");

        }

        public ActionResult EditStudent(int id)
        {
            var db = new DemoF23_CEntitiesEntities();
            var ex = (from d in db.Students
                      where d.Id == id
                select d).SingleOrDefault();
            return View(ex);

        }
        [HttpPost]
        public ActionResult EditStudent(Student d)
        {
            var db = new DemoF23_CEntitiesEntities();
            var exdata = db.Students.Find(d.Id);
            exdata.Name = d.Name;
            exdata.Cgpa = d.Cgpa;
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var db = new DemoF23_CEntitiesEntities();
            var exdata = db.Students.Find(id);
            return View(exdata);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student d, string action)
        {
            if (action == "Delete")
            {
                var db = new DemoF23_CEntitiesEntities();
                var exdata = db.Students.Find(d.Id);
                db.Students.Remove(exdata);
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            else
            {
                return RedirectToAction("StudentList");
            }
        }
    }
}