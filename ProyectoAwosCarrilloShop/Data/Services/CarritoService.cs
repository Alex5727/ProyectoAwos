using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAwosCarrilloShop.Data.Services
{
    public class CarritoService
    {
        private AppDBcontext _context;
        private readonly DetalleCarritoService _detcaroService;

        public CarritoService(AppDBcontext context, DetalleCarritoService detcaroService)
        {
            _context = context;
            _detcaroService = detcaroService;
        }

        public void AddCarrito(CarritoVM carrito)
        {
            var _carrito = new Carrito()
            {
                CliID = carrito.ClienteID,
                estado = true,
            };
            _context.Carritos.Add(_carrito);
            _context.SaveChanges();
        }

        public List<Carrito> GetAllCarritos() => _context.Carritos.ToList();

        public void DeleteCarritoByID(int carid)
        {
            var _carrito = _context.Carritos.FirstOrDefault(n => n.CarritoID == carid);
            if (_carrito != null)
            {
                _context.Carritos.Remove(_carrito);
                _context.SaveChanges();
            }
        }

        public void CarritoComprar(int carid)
        {
            _detcaroService.ComprarCarrito(carid);

            var carrito = _context.Carritos.FirstOrDefault(c => c.CarritoID == carid);
            if (carrito != null)
            {
                carrito.estado = false;
                _context.SaveChanges();
            }
        }




    }
}
