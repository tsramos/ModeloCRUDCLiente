using System;
using System.Collections.Generic;
using System.Text;
using CRUDCLiente.Dominio.Entidades;
using CRUDCLiente.Infra.Repositorio;

namespace CRUDCLiente.Servico
{
    internal class ClienteService
    {
        private ClienteRepositorio _clienteRepositorio;

        public void Add(Cliente cliente)
        {
            if(!ValidarCliente(cliente))            
                Console.WriteLine("Erro ao adicionar cliente");
            _clienteRepositorio = new ClienteRepositorio();
            _clienteRepositorio.Add(cliente);
        }

        public List<Cliente> GetAll()
        { 
            _clienteRepositorio = new ClienteRepositorio();
            return _clienteRepositorio.GetClientes();
        }

        private bool ValidarCliente(Cliente cliente)
        {
            if (cliente == null) 
                return false;
            else if(string.IsNullOrWhiteSpace(cliente.Nome) &&
                    string.IsNullOrWhiteSpace(cliente.Email) &&
                    cliente.DataNascimento != DateTime.MinValue) 
                return false;
            return true;            
        }
    }
}
