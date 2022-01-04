using System.Collections.Generic;
using System.Linq;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Data.Repository
{
    public class EmployeeMockedRepository : IEmployeeRepo
    {
        static int counter=3;
      static  List<Employee> emplist = new List<Employee>()
            {
               new Employee(){Id=1,Name="Abhinav",City="Mumbai",Description="This is First Employee"},
                new Employee(){Id=2,Name="Sonam",City="Delhi",Description="This is Second Employee"},
                new Employee(){Id=3,Name="Utkarsh",City="Lucknow",Description="This is Third Employee"}
            };

        public void CreateEmployees(Employee emp)
        {
           counter = counter+1;
           emp.Id=counter;
           emplist.Add(emp);
        }

        public void DeleteEmployees(Employee emp)
        {
             emplist.Remove(emp);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return emplist;
        }

        public Employee GetEmployeeById(int id)
        {
            return emplist.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            //do Nothing
            return true;
        }

        public void UpdateEmployees(Employee emp)
        {
            //do Nothing
        }
    }

}