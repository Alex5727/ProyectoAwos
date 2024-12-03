using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using ProyectoAwosCarrilloShop.Exeptions;
using System.Collections.Generic;
using System.Linq;
using static ProyectoAwosCarrilloShop.Exeptions.CarritoVacioExeption;
using static System.Reflection.Metadata.BlobBuilder;

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
                estado = false,
            };
            _context.Carritos.Add(_carrito);
            _context.SaveChanges();
        }

        public Carrito UpdateEstado(int carritoID)
        {
            var _Carrito = _context.Carritos.FirstOrDefault(n => n.CarritoID == carritoID);
            if (_Carrito != null)
            {
                _Carrito.estado = true;

                _context.SaveChanges();
            }
            return _Carrito;
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

        public CarritoVM GetCarritoByID(int carID)
        {
            var _carrito = _context.Carritos.Where(n => n.CarritoID == carID).Select(carrito => new CarritoVM()
            {
                ClienteID = carrito.CliID,
            }).FirstOrDefault();
            return _carrito;
        }

        public void CarritoComprar(int carid)
        {

            var carr = GetCarritoByID(carid);

            if (carr != null)
            {
                var carrito = _context.Carritos.FirstOrDefault(c => c.CarritoID == carid);
                if (carrito != null)
                {
                    carrito.estado = false;
                    _context.SaveChanges();
                }

                _detcaroService.ComprarCarrito(carid);
            }
            else
            {
                throw new CarritoVacioExeption("No existe el carrito seleccionado.");
            }
        }




    }
}
