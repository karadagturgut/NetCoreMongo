using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDeneme.Model;

namespace MongoDeneme
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

        }

        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<Employee> employees;
            employees = _employees.Find(x => true).ToList();
            return employees;
        }

        public Employee GetById(string id)
        {
            return _employees.Find(x => x.Id == id).FirstOrDefault();
        }

        public Employee Create(Employee model)
        {
            _employees.InsertOne(model);
            return model;
        }

        public Employee Update (string id, Employee model)
        {
            _employees.ReplaceOne(x=>x.Id==id, model);
            var result = _employees.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public void DeleteById(string id)
        {
            _employees.DeleteOne(x=>x.Id== id);
        }
    }
}