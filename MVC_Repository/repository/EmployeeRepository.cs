using MVC_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVC_Repository.repository
{
    public class EmployeeRepository : IEmployee
    {

        private EmployeeDBEntities DBContext;

        public EmployeeRepository(EmployeeDBEntities objempcontext)
        {
            this.DBContext = objempcontext;
        }

        public void InsertEmployee(Employee employee)
        {
            DBContext.Employees.Add(employee);
            DBContext.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return DBContext.Employees.ToList();
        }

        public Employee GetEmployeeByID(int employeeid)
        {
          return DBContext.Employees.Find(employeeid);
        }

        public void UpdateEmployee(Employee employee)
        {
            DBContext.Entry(employee).State = EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void DeleteEmployee(int employeeid)
        {
            Employee user = DBContext.Employees.Find(employeeid);
            DBContext.Employees.Remove(user);
            DBContext.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}