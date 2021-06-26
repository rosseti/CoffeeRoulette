using CoffeeRoulette.Domain;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeRoulette.Infrastructure.Storage
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private readonly string dbPath;

        public EmployeeDAO(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public void Add(Employee employee)
        {
            using LiteDatabase db = new LiteDatabase(this.dbPath);
            db.GetCollection<Employee>().Insert(employee);
        }

        public Employee Get(int id)
        {
            return Execute<Employee>((collection) =>
            {
                return collection.Find(e => e.Id == id).FirstOrDefault();
            });
        }

        public IEnumerable<Employee> GetAll()
        {
            return Execute((collection) => collection.FindAll().ToList());
        }

        private void Execute(Action<ILiteCollection<Employee>> action)
        {
            using LiteDatabase db = new LiteDatabase(this.dbPath);
            action(db.GetCollection<Employee>());
        }

        private T Execute<T>(Func<ILiteCollection<Employee>, T> action)
        {
            using LiteDatabase db = new LiteDatabase(this.dbPath);
            return action(db.GetCollection<Employee>());
        }
    }
}
