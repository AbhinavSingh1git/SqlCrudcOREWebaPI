using EmployeeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Data.EntityCore
{
   public class EmployeeContext :DbContext
   {
      public EmployeeContext(DbContextOptions<EmployeeContext> opt):base(opt)
      {}
      
      public DbSet<Employee> Employees{get;set;}
  
   }


}