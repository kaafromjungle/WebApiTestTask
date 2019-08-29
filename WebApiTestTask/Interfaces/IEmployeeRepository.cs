using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTestTask.Model;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;

namespace WebApiTestTask.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task AddEmployee(Employee item);
        Task<DeleteResult> RemoveEmployee(int id);
        Task<IEnumerable<Employee>> GetCompanyEmployees(int CompanyId);
        Task<UpdateResult> UpdateEmployee(int id, Employee item);

        Task<DeleteResult> RemoveAllEmployees();
    }
}
