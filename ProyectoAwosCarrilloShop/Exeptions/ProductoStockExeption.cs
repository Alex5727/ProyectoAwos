using System;

namespace ProyectoAwosCarrilloShop.Exeptions
{
    public class ProductoStockExeption:Exception
    {
        public class StockInsuficienteException : Exception
        {
            public StockInsuficienteException(string message) : base(message) { }
        }

    }
}
