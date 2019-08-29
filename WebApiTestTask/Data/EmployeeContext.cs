using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiTestTask.Model;

namespace WebApiTestTask.Data
{
    public class EmployeeContext
    {
        private readonly IMongoDatabase _database = null;
        
        public EmployeeContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            
                _database = client.GetDatabase(settings.Value.Database);
            
        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return _database.GetCollection<Employee>("Employee");
            }
        }
    }
}
