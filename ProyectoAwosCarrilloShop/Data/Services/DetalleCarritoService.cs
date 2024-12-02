using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using static ProyectoAwosCarrilloShop.Exeptions.ProductoStockExeption;

namespace ProyectoAwosCarrilloShop.Data.Services
{
    public class DetalleCarritoService
    {
        private AppDBcontext _context;
        private readonly ProductoService _productoService;
        public DetalleCarritoService(AppDBcontext context, ProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        public void AddDetCar2(DetalleCarritoVM detallescarrito)
        {
            var _detCar = new DetalleCarrito()
            {
                CarritoID = detallescarrito.CarritoID,
                ID = detallescarrito.ID,
                Cantidad = detallescarrito.Cantidad,
                Subtotal = 10,
            };
            _context.DetallesCarrito.Add(_detCar);
            _context.SaveChanges();
        }

        public void AddDetCar(DetalleCarritoVM detallescarrito)
        {
            int stokcProducto = _productoService.GetProductStockByID(detallescarrito.ID);
            int precioProducto = _productoService.GetProductPriceByID(detallescarrito.ID);

            if (stokcProducto <= 0)
            {
                throw new StockInsuficienteException("No hay suficiente stock para el producto.");
            }


            var _detCar = new DetalleCarrito()
                {
                    CarritoID = detallescarrito.CarritoID,
                    ID = detallescarrito.ID,
                    Cantidad = detallescarrito.Cantidad,
                    Subtotal = (precioProducto * detallescarrito.Cantidad),
                };
                _context.DetallesCarrito.Add(_detCar);
                _context.SaveChanges();
        }

        public List<DetalleCarrito> GetAllDetCarr() => _context.DetallesCarrito.ToList();

        public List<DetalleCarrito> GetDetCarByCarID(int CarID) => _context.DetallesCarrito.Where(n => n.CarritoID == CarID).ToList();


        public void DeleteDetalleCarrito(int carritoId, int productoId)
        {
            var detalleCarrito = _context.DetallesCarrito.FirstOrDefault(dc => dc.CarritoID == carritoId && dc.ID == productoId);

            if (detalleCarrito != null)
            {
                _context.DetallesCarrito.Remove(detalleCarrito);
                _context.SaveChanges();
            }
        }

        public void ComprarCarrito(int carritoId)
        {
            // Materializar la lista de DetallesCarrito
            var detallesCarrito = _context.DetallesCarrito
                .Where(dc => dc.CarritoID == carritoId)
                .ToList();

            foreach (var detalle in detallesCarrito)
            {
                // Bajar stock del producto asociado
                _productoService.BajarStock(detalle.ID);

                // Eliminar el detalle del carrito
                _context.DetallesCarrito.Remove(detalle);
            }

            _context.SaveChanges();
        }


    }
}
