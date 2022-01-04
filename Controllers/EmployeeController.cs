using System.Collections.Generic;
using AutoMapper;
using EmployeeWebApi.Data;
using EmployeeWebApi.Dtos;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeWebApi.Controllers
{  //  [Route("[controller]")]
    [ApiController]
    [Route("api/Employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //Get->api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployee()
        {
            var emps = _repository.GetAllEmployee();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(emps));
        }

        //Get->api/Employees/id
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var emp = _repository.GetEmployeeById(id);
            if (emp == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeReadDto>(emp));
        }

        //post->api/Employees/
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(EmployeeCreatedto empInput)
        {
            var emp = _mapper.Map<Employee>(empInput);
            _repository.CreateEmployees(emp);
            _repository.SaveChanges();
            var empout = _mapper.Map<EmployeeReadDto>(emp);
            return CreatedAtRoute(nameof(GetEmployeeById), new { id = empout.Id }, empout);
        }


        //put->api/Employees/id
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdatedto emptoupdated)
        {
            var empfromrepo = _repository.GetEmployeeById(id);
            if (empfromrepo == null)
                return NotFound();
            /*The employee object from repository will be overridedn by employee object send by client*/
            _mapper.Map(emptoupdated, empfromrepo);

            _repository.UpdateEmployees(empfromrepo);
            _repository.SaveChanges();

            return NoContent();
        }


        //put->api/Employees/id
        [HttpPatch("{id}")]
        public ActionResult PatchUpdateEmployee(int id, JsonPatchDocument<EmployeeUpdatedto> patchDoc)
        {
            var empfromrepo = _repository.GetEmployeeById(id);
            if (empfromrepo == null)
                return NotFound();

            var employeeWithPatchUpdate = _mapper.Map<EmployeeUpdatedto>(empfromrepo);
            patchDoc.ApplyTo(employeeWithPatchUpdate, ModelState);

            if (!TryValidateModel(employeeWithPatchUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeWithPatchUpdate, empfromrepo);
            _repository.UpdateEmployees(empfromrepo);
            _repository.SaveChanges();

            return NoContent();
        }

       [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var empfromrepo = _repository.GetEmployeeById(id);
            if (empfromrepo == null)
                return NotFound();
                
            _repository.DeleteEmployees(empfromrepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }

}
