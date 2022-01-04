using System.Collections.Generic;
using System.Linq;
using EmployeeWebApi.Data.EntityCore;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Data.Repository
{
   public class EmployeeSqlRepository : IEmployeeRepo
    {
       private readonly EmployeeContext _context;
        public EmployeeSqlRepository(EmployeeContext context)
        {
           _context = context;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
         return   _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
           return   _context.Employees.FirstOrDefault(x=>x.Id==id);
        }
        public void CreateEmployees(Employee emp)
        {
           _context.Employees.Add(emp);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateEmployees(Employee emp)
        {
           //do nothing
        }

        public void DeleteEmployees(Employee emp)
        {
          _context.Employees.Remove(emp);
        }
    }
}