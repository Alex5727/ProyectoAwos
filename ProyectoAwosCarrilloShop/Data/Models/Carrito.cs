using System.Collections.Generic;

namespace ProyectoAwosCarrilloShop.Data.Models
{
    public class Carrito
    {
        public int CarritoID { get; set; }
        public int CliID { get; set; }
        public bool estado { get; set; }
        public Cliente Cliente { get; set; }

        public List<DetalleCarrito> DetallesCarrito { get; set; }
    }
}
