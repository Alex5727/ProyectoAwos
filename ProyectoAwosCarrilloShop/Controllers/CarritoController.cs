﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAwosCarrilloShop.Data.Services;
using ProyectoAwosCarrilloShop.Data.ViewModels;

namespace ProyectoAwosCarrilloShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {

        public CarritoService _carritoservice;

        public CarritoController(CarritoService carritoservice)
        {
            _carritoservice = carritoservice;
        }


        [HttpGet("get-all-Carritos")]
        public IActionResult GetAllCarritos()
        {
            var allcarritos = _carritoservice.GetAllCarritos();
            return Ok(allcarritos);
        }

        [HttpPost("add-Carrito")]
        public IActionResult AddCarrito([FromBody] CarritoVM carrito)
        {
            _carritoservice.AddCarrito(carrito);
            return Ok();
        }

        [HttpDelete("delete-carrito-by-id/{id}")]
        public IActionResult DeleteCarritoByID(int id)
        {
            _carritoservice.DeleteCarritoByID(id);
            return Ok();
        }


        [HttpPost("comprar-carrito/{carritoId}")]
        public IActionResult ComprarCarrito(int carritoId)
        {
            _carritoservice.CarritoComprar(carritoId);
            return Ok(new { message = "El carrito ha sido comprado exitosamente y su estado ha sido actualizado." });
        }
    }
}
