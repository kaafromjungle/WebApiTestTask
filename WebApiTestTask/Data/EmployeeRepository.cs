using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using WebApiTestTask.Interfaces;
using WebApiTestTask.Model;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using MongoDB.Bson.Serialization;

namespace WebApiTestTask.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context = null;

        public EmployeeRepository(IOptions<Settings> settings)
        {
            _context = new EmployeeContext(settings);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetCompanyEmployees(int CompanyId)
        {
            var filter = Builders<Employee>.Filter.Eq("CompanyId", CompanyId);
            try
            {
                return await _context.Employees.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddEmployee(Employee item)
        {
            try
            {
                await _context.Employees.InsertOneAsync(item);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveEmployee(int id)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", id);
            try
            {
                return await _context.Employees.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<UpdateResult> UpdateEmployee(int id, Employee item)
        {
             
            var filter = Builders<Employee>.Filter.Eq("Id", id);
            var doc = _context.Employees.Find(filter).First();
            if (item.Id == 0) { item.Id = doc.Id; };
            if (item.Name == null) { item.Name = doc.Name; };
            if (item.Surname == null) { item.Surname = doc.Surname; };
            if (item.Phone == null) { item.Phone = doc.Phone; };
            if (item.CompanyId == 0) { item.CompanyId = doc.CompanyId; };
            if (item.Passport == null) { item.Passport = doc.Passport; };
            //if (item.Passport.Type == null) { item.Passport.Type = doc.Passport.Type; };
            //if (item.Passport.Number == null) { item.Passport.Number = doc.Passport.Number; };

            var update = Builders<Employee>.Update.Set("Name", item.Name)
                .Set("Surname", item.Surname)
                .Set("Phone", item.Phone)
                .Set("CompanyId", item.CompanyId)
                .Set("Passport", item.Passport);
              //  .Set("Passport.Type", item.Passport.Type)
                //.Set("Passport.Number", item.Passport.Number);

            return await _context.Employees.UpdateOneAsync(filter, update);
             
           
            
        }
        

        public async Task<DeleteResult> RemoveAllEmployees()
        {
            try
            {
                return await _context.Employees.DeleteManyAsync(new BsonDocument());
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
