using ProyectoAwosCarrilloShop.Data.Models;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static ProyectoAwosCarrilloShop.Exeptions.ProductoStockExeption;

namespace ProyectoAwosCarrilloShop.Data.Services
{
    public class ProductoService
    {
        private AppDBcontext _context;

        public ProductoService(AppDBcontext context)
        {
            _context = context;
        }

        public void AddProducto(ProductoVM producto)
        {
            var _producto = new Producto()
            {
                Nombre = producto.Nombre,
                Descripccion = producto.Descripccion,
                Precio = producto.Precio,
                Stock = producto.Stock
            };
            _context.Productos.Add(_producto);
            _context.SaveChanges();
        }

        public List<Producto> GetAllProductos() => _context.Productos.ToList();


        public ProductoVM GetProductByID(int productoID)
        {
            var _producto = _context.Productos.Where(n => n.ID == productoID).Select(producto => new ProductoVM()
            {
                Nombre = producto.Nombre,
                Descripccion = producto.Descripccion,
                Precio = producto.Precio,
                Stock = producto.Stock
            }).FirstOrDefault();
            return _producto;
        }

        public int GetProductPriceByID(int productoID)
        {
            var precio = _context.Productos
                .Where(n => n.ID == productoID)
                .Select(producto => producto.Precio)
                .FirstOrDefault();
            return precio;
        }

        public int GetProductStockByID(int productoID)
        {
            var stock = _context.Productos
                .Where(n => n.ID == productoID)
                .Select(producto => producto.Stock)
                .FirstOrDefault();
            return stock;
        }

        public void DeleteProductoByID(int proid)
        {
            var _producto = _context.Productos.FirstOrDefault(n => n.ID == proid);
            if (_producto != null)
            {
                _context.Productos.Remove(_producto);
                _context.SaveChanges();
            }
        }

        public void BajarStock(int proid, int canp)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.ID == proid);
            if (producto != null)
            {
                if (producto.Stock >= canp)
                {
                    producto.Stock = producto.Stock - canp;
                    _context.SaveChanges();
                }
                else
                {
                    throw new StockInsuficienteException("No hay suficiente stock para el producto.");
                }
            }
        }


    }
}
