using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeRoulette.Domain
{
    public class Roulette
    {
        private readonly IEmployeeDAO employeeDAO;

        public Roulette(IEmployeeDAO employeeDAO)
        {
            this.employeeDAO = employeeDAO;
        }
        public Employee NextVictim(IEnumerable<Employee> volunteers)
        {
            IEnumerable<Employee> employees = employeeDAO.GetAll();
            IEnumerable<Employee> eligibles = employees
                .Where(e => !e.LastToMakeCoffee)
                .Where(
                    e => volunteers.Any() || volunteers.Any(v => v.Id == e.Id)
                );

            if (!eligibles.Any())
            {
                eligibles = employees;
            }

            Employee[] array = eligibles.ToArray();
            Random random = new Random();

            return array[random.Next(0, array.Length)];
        }
    }
}
