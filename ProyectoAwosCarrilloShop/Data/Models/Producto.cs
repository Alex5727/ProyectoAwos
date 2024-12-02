using System.Collections.Generic;

namespace ProyectoAwosCarrilloShop.Data.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripccion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public List<DetalleCarrito> DetallesCarrito { get; set; }

    }
}
