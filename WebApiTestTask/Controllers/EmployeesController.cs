using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTestTask.Interfaces;
using WebApiTestTask.Model;
using WebApiTestTask.Infrastructure;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace WebApiTestTask.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json","miultipart/form-data")]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Employee>> Get()
        {
            return GetEmployeeInternal();
        }
        private async Task<IEnumerable<Employee>> GetEmployeeInternal()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        //GET api/employees/byComp/2
        [HttpGet("{CompanyId}")]
        public async Task<IEnumerable<Employee>> GetCompanyEmployees(int CompanyId)
        {
            return await _employeeRepository.GetCompanyEmployees(CompanyId);
        }

        //DELETE api/employees/1
        [HttpDelete("{Id}")]
        public async void Delete(int id)
        {
            await _employeeRepository.RemoveEmployee(id);
        }

        //Post api/employees
        [HttpPost]
        public async Task<int> Post([FromBody] Employee newEmployee)
        {
            await _employeeRepository.AddEmployee(new Employee()
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
                Surname = newEmployee.Surname,
                Phone = newEmployee.Phone,
                CompanyId = newEmployee.CompanyId,
                Passport = newEmployee.Passport
            });
            return newEmployee.Id;
             
        }
        
        //Patch api/employees
        [HttpPatch("{Id}")]
        public void Patch(int id, [FromBody]Employee newEmployee)
        {
            _employeeRepository.UpdateEmployee(id, newEmployee);
        }
        
    }
}
