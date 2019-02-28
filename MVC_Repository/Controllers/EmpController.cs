using MVC_Repository.Models;
using MVC_Repository.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository.Controllers
{
    public class EmpController : Controller
    {
        private IEmployee Iemp;

        public EmpController()
        {
            this.Iemp = new EmployeeRepository(new EmployeeDBEntities());
        }

        // GET: Emp
        public ActionResult Index()
        {
            var list = Iemp.GetEmployees();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var objemp = Iemp.GetEmployeeByID(id);
            var employee = new Employee();
            employee.EmpID = id;
            employee.Name = objemp.Name;
            employee.Salary = objemp.Salary;
            employee.Age = objemp.Age;
            employee.Address = objemp.Address;
            employee.Worktype = objemp.Worktype;
            
            return View(employee);
        }

        public ActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection,Employee objemp)
        {
            try
            {
                var employee = new Employee();
                employee.EmpID = 0;
                employee.Name = objemp.Name;
                employee.Salary = objemp.Salary;
                employee.Age = objemp.Age;
                employee.Address = objemp.Address;
                employee.Worktype = objemp.Worktype;
                Iemp.InsertEmployee(employee);

                return  RedirectToAction("Index");
            }
            catch (Exception)
            {             
               return View();
            }

        }

        public ActionResult Edit(int id)
        {
            var objemp = Iemp.GetEmployeeByID(id);
            var employee = new Employee();
            employee.EmpID = id;
            employee.Name = objemp.Name;
            employee.Salary = objemp.Salary;
            employee.Age = objemp.Age;
            employee.Address = objemp.Address;
            employee.Worktype = objemp.Worktype;

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, Employee objemp)
        {
            try
            {
                var employee = new Employee();
                Iemp.UpdateEmployee(objemp);

               return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            var employee = Iemp.GetEmployeeByID(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee objemp)
        {
            try
            {
                Iemp.DeleteEmployee(id);

                return  RedirectToAction("Index");
            }
            catch 
            {

                return View();
            }

        }

    }
}