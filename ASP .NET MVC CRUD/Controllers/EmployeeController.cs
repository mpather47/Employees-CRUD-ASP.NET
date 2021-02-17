using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_CRUD.Models;

namespace ASP.NET_MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetData()
        {
            using (DBModels db = new DBModels())
            {
                List<Employee> empList = db.Employees.ToList<Employee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id ==0)
                return View(new Employee());
            else
            {
                using (DBModels db = new DBModels())
                {
                    return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>());
                }
            }

        }


        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (DBModels db = new DBModels())
            {
                if(emp.EmployeeID == 0)
                {
                    db.Employees.Add(emp);

                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }

            }
            
            
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using(DBModels db = new DBModels())
            {
                Employee emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }

}