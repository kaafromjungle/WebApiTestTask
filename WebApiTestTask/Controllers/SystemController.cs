using System;
using Microsoft.AspNetCore.Mvc;

using WebApiTestTask.Interfaces;
using WebApiTestTask.Model;

namespace WebApiTestTask.Controllers
{
    [Route("api/system")]
    public class SystemController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public SystemController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _employeeRepository.RemoveAllEmployees();
                _employeeRepository.AddEmployee(new Employee()
                {
                    Id = 1,
                    Name = "Ivan",
                    Surname = "Ivanov",
                    Phone = "000-001",
                    CompanyId = 1,
                        Passport = new Passport
                        {
                            Type = "Official",
                            Number = "1234 565676"
                        }
                });

                _employeeRepository.AddEmployee(new Employee()
                {
                    Id = 2,
                    Name = "Stepan",
                    Surname = "Stepanov",
                    Phone = "000-002",
                    CompanyId = 1,
                        Passport = new Passport
                        {
                            Type = "Regular",
                            Number = "1223 262746"
                        }
                });

                _employeeRepository.AddEmployee(new Employee()
                {
                    Id = 3,
                    Name = "Alex",
                    Surname = "Alexadrov",
                    Phone = "000-003",
                    CompanyId = 2,
                        Passport = new Passport
                        {
                            Type = "Regular",
                            Number = "5745 123846"
                        }
                });

                _employeeRepository.AddEmployee(new Employee()
                {
                    Id = 4,
                    Name = "Anrew",
                    Surname = "Peskov",
                    Phone = "130-482",
                    CompanyId = 3,
                    Passport = new Passport
                    {
                        Type = "Dyplomatic",
                        Number = "1223 262746"
                    }
                });

                return "Done";
            }

            return "Unknown";
        }
    }
}
