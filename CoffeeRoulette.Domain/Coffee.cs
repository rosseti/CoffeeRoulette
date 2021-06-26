using System;

namespace CoffeeRoulette.Domain
{
    public partial class Employee
    {
        public class Coffee
        {
            public  DateTime CreationTime { get; set; }
            public Employee Barista { get; set; }

            public Quality Quality { get; set; }

        }
    }
}
