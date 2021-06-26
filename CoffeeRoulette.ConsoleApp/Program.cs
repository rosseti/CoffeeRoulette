using System;

namespace CoffeeRoulette.ConsoleApp
{
    class Program
    {
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
            throw new NotImplementedException();
        }

        private static void CadastrarFuncionario()
        {
            throw new NotImplementedException();
        }
    }
}
