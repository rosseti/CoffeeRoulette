namespace CoffeeRoulette.Domain
{
    public class HumanResources
    {
        private readonly IEmployeeDAO employeeDAO;

        public HumanResources(IEmployeeDAO employeeDAO)
        {
            this.employeeDAO = employeeDAO;
        }

        public void AddNewEmployee(Employee employee)
        {
            if (this.employeeDAO.Get(employee.Id) != null)
                throw new DuplicatedEmployeeException($"Já existe um funcionário com o id {employee.Id}");

            this.employeeDAO.Add(employee);
        }
    }
}
