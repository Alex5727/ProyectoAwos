using System.Collections.Generic;

namespace ProyectoAwosCarrilloShop.Data.Models
{
    public class DetalleCarrito
    {
        public int CarritoID { get; set; }
        public Carrito Carrito { get; set; }
        public int ID { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
    }
}
