using System;

namespace ProyectoAwosCarrilloShop.Exeptions
{
    public class CarritoVacioExeption:Exception
    {
        public CarritoVacioExeption(string message) : base(message)
        {
        }

        public class carritovacionException : Exception
        {
            public carritovacionException(string message) : base(message) { }
        }

    }
}
