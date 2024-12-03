using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using static ProyectoAwosCarrilloShop.Exeptions.ProductoStockExeption;
using System.Net;
using static ProyectoAwosCarrilloShop.Exeptions.CarritoVacioExeption;
using ProyectoAwosCarrilloShop.Exeptions;

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



            bool existe = BuscarCarProductoByID(detallescarrito.CarritoID, detallescarrito.ID);

            if (existe)
            {
                var _detCar = new DetalleCarrito()
                {
                    CarritoID = detallescarrito.CarritoID,
                    ID = detallescarrito.ID,
                    Cantidad = detallescarrito.Cantidad,
                    Subtotal = (precioProducto * detallescarrito.Cantidad),
                };

                if (stokcProducto < detallescarrito.Cantidad)
                {
                    throw new StockInsuficienteException("No hay suficiente stock para el producto.");
                }

                var _Carrito = _context.Carritos.FirstOrDefault(n => n.CarritoID == detallescarrito.CarritoID);
                if (_Carrito != null)
                {
                    _Carrito.estado = true;

                    _context.SaveChanges();
                }


                _context.DetallesCarrito.Add(_detCar);
                _context.SaveChanges();
            }
            else
            {
                var _detCar = _context.DetallesCarrito.FirstOrDefault(dc => dc.CarritoID == detallescarrito.CarritoID && dc.ID == detallescarrito.ID);

                if (stokcProducto >= detallescarrito.Cantidad + _detCar.Cantidad)
                {
                    _detCar.Cantidad = _detCar.Cantidad + detallescarrito.Cantidad;
                }
                else
                {
                    throw new StockInsuficienteException("No hay suficiente stock para el producto.");
                }
                _context.SaveChanges();

            }
        }

        public bool BuscarCarProductoByID(int Caritoid, int productoid)
        {
           var detcar = _context.DetallesCarrito.FirstOrDefault(dc => dc.CarritoID == Caritoid && dc.ID == productoid);

            if(detcar != null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            var detallesCarrito = _context.DetallesCarrito
                .Where(dc => dc.CarritoID == carritoId)
                .ToList();

            if (detallesCarrito.Capacity == 0)
            {
                throw new CarritoVacioExeption("No hay productos en este carrito.");
            }
            else
            {
            foreach (var detalle in detallesCarrito)
            {
                _productoService.BajarStock(detalle.ID, detalle.Cantidad);

                _context.DetallesCarrito.Remove(detalle);
            }
            _context.SaveChanges();
            }
        }


    }
}
