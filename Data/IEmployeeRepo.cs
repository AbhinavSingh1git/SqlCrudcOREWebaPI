
using System.Collections.Generic;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Data
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);

        void CreateEmployees(Employee emp);

        void UpdateEmployees(Employee emp);

        void DeleteEmployees(Employee emp);

        bool SaveChanges();
    }


}