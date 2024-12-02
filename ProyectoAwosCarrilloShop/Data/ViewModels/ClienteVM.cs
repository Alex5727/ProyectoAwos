using ProyectoAwosCarrilloShop.Data.Models;
using System;

namespace ProyectoAwosCarrilloShop.Data.ViewModels
{
    public class ClienteVM
    {
        public string CliNombre { get; set; }
        public string CliEmail { get; set; }
        public string CliPassword { get; set; }
        public string CliCelular { get; set; }
        public string CliDir { get; set; }
        public DateTime CliFechReg { get; set; }

    }
}
