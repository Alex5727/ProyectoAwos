using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ProyectoAwosCarrilloShop.Data.Services
{
    public class ClienteService
    {
        private AppDBcontext _context;

        public ClienteService(AppDBcontext context)
        {
            _context = context;
        }

        public void AddCliente(ClienteVM cliente)
        {
            var _cliente = new Cliente()
            {
                CliNombre = cliente.CliNombre,
                CliEmail = cliente.CliEmail,
                CliPassword = cliente.CliPassword,
                CliCelular = cliente.CliCelular,
                CliDir = cliente.CliDir,
                CliFechReg = DateTime.Now,

            };
            _context.Clientes.Add(_cliente);
            _context.SaveChanges();
        }
        public List<Cliente> GetAllClt() => _context.Clientes.ToList();



        public ClienteVM GetClienteByID(int clienteID)
        {
            var _cliente = _context.Clientes.Where(n => n.CliID == clienteID).Select(cliente => new ClienteVM()
            {
                CliNombre = cliente.CliNombre,
                CliEmail = cliente.CliEmail,
                CliPassword = cliente.CliPassword,
                CliCelular = cliente.CliCelular,
                CliDir = cliente.CliDir,
                CliFechReg = DateTime.Now,
            }).FirstOrDefault();
            return _cliente;
        }

        public void DeleteClienteByID(int cliid)
        {
            var _cliente = _context.Clientes.FirstOrDefault(n => n.CliID == cliid);
            if (_cliente != null)
            {
                _context.Clientes.Remove(_cliente);
                _context.SaveChanges();
            }
        }


    }
}
