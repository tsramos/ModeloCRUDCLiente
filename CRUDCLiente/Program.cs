using System;
using CRUDCLiente.Controllers;
using CRUDCLiente.Dominio.Enumeradores;
namespace CRUDCLiente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OpcaoEnum opcao = 0;

            do
            {
                Console.WriteLine("Escolha dentre as opções");
                Console.WriteLine("1) Cadastrar cliente\n2) Listar todos");
                MenuEnum menu = Enum.Parse<MenuEnum>(Console.ReadLine());

                switch (menu)
                {
                    case MenuEnum.Adicionar:
                        {
                            ClienteController clienteController = new ClienteController();
                            Console.WriteLine("Insira o nome do cliente");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o e-mail do cliente");
                            string email = Console.ReadLine();
                            Console.WriteLine("Informe a data de nascimento");
                            DateTime nascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.AddCliente(nome, email, nascimento);
                        }
                        break;
                    case MenuEnum.ListarTodos:
                        {
                            ClienteController clienteController = new ClienteController();
                            var clientes = clienteController.GetClientes();
                            clientes.ForEach(cliente => Console.WriteLine(
                                            $"Cliente : {cliente.Nome}\n" +
                                            $"Data de Nascimento: {cliente.DataNascimento.ToString("dd-MM-yyyy")}\n" +
                                            $"Email : {cliente.Email}")                             
                                          ) ;
                            break;
                        }
                    default:
                        break;
                }

                Console.WriteLine("Deseja realizar outra operação");
                opcao = Enum.Parse<OpcaoEnum>(Console.ReadLine());
                Console.Clear();

            } while (opcao != OpcaoEnum.Nao);
        }
    }
}
