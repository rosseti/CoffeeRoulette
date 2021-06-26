using System.Collections.Generic;

namespace CoffeeRoulette.Domain
{
    public interface IEmployeeDAO
    {
        Employee Get(int id);
        IEnumerable<Employee> GetAll();

        void Add(Employee employee);
    }
}
