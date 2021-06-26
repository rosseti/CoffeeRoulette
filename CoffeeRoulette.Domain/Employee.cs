using System;

namespace CoffeeRoulette.Domain
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Proficiency Proficiency { get; set; }

        public bool LastToMakeCoffee { get; set; }
        public DateTime LastCoffee { get; set; }

        public Coffee MakeCoffee(bool isVolunteer)
        {
            return new Coffee();
        }
    }
}
