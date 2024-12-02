using System;

namespace ProyectoAwosCarrilloShop.Data.Models
{
    public class Cliente
    {
        public int CliID { get; set; }
        public string CliNombre { get; set; }
        public string CliEmail { get; set; }
        public string CliPassword { get; set; }
        public string CliCelular { get; set; }
        public string CliDir { get; set; }
        public DateTime CliFechReg { get; set; }

        public Carrito Carrito { get; set; }
    }
}
