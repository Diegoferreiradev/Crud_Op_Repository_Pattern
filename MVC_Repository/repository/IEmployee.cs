using MVC_Repository.Models;
using System.Collections.Generic;

namespace MVC_Repository.repository
{
    interface IEmployee
    {
        void InsertEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int employeeid);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeid);
    }
}
