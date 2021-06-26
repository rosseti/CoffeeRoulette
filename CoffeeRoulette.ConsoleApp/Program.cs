using CoffeeRoulette.Domain;
using CoffeeRoulette.Infrastructure.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeRoulette.ConsoleApp
{
    class Program
    {
        private const string dbPath = @"C:\Users\andrei\workshop\CoffeeRoulette\database.db";
        private static IEmployeeDAO employeeDAO = new EmployeeDAO(dbPath);
        private static Roulette roulette = new Roulette(employeeDAO);
        static void Main(string[] args)
        {
            string command;

            do
            {
                Console.WriteLine("Digite o comando: ");
                Console.WriteLine("1 - Cadastrar funcionário");
                Console.WriteLine("2 - Escolher funcionário para fazer café");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        CadastrarFuncionario();
                        break;

                    case "2":
                        EscolherFuncionario();
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Digitou errado, informe outra opção");
                        break;
                }

            } while (command != "9");

        }

        private static void EscolherFuncionario()
        {
            Console.WriteLine("Informe os IDs dos funcionários voluntários separados por vírgula!");
            string idsVoluntariosString = Console.ReadLine();
            int[] idsVoluntarios = idsVoluntariosString.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            IEnumerable<Employee> voluntarios = employeeDAO.GetAll().Where(e => idsVoluntarios.Contains(e.Id));
            Employee employee = roulette.NextVictim(voluntarios);
            if (employee != null)
            {
                Console.WriteLine("E o escolhido foi...");
                Console.WriteLine(employee.Name);
            }
        }

        private static void CadastrarFuncionario()
        {
            int id;
            do
            {
                Console.WriteLine("Digite o ID do novo funcionário");
            } while (!int.TryParse(Console.ReadLine(), out id));

            Console.WriteLine("Digite o nome do novo funcionário");
            string nome = Console.ReadLine();

            int idade;
            do
            {
                Console.WriteLine("Digite o idade do novo funcionário");
            } while (!int.TryParse(Console.ReadLine(), out idade));
            Proficiency capacidade;
            do
            {
                Console.WriteLine("Digite o capacidade do novo funcionário");
            } while (!Enum.TryParse<Proficiency>(Console.ReadLine(), out capacidade));

            Employee employee = new Employee
            {
                Id = id,
                Name = nome,
                Age = idade,
                Proficiency = capacidade
            };
            employeeDAO.Add(employee);
            Console.WriteLine("Funcionário cadastrado com sucesso!");
        }
    }
}
