using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAwosCarrilloShop.Data.Services;
using ProyectoAwosCarrilloShop.Data.ViewModels;
using System;
using static ProyectoAwosCarrilloShop.Exeptions.ProductoStockExeption;

namespace ProyectoAwosCarrilloShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarritoController : ControllerBase
    {
        public DetalleCarritoService _detalleCarritoService;

        public DetalleCarritoController(DetalleCarritoService detalleCarritoService)
        {
            _detalleCarritoService = detalleCarritoService;
        }




        [HttpGet("get-all-DetCar")]
        public IActionResult GetAllDetCarr()
        {
            var allDetCarr = _detalleCarritoService.GetAllDetCarr();
            return Ok(allDetCarr);
        }

        [HttpPost("add-DetCar")]
        public IActionResult AddDetCar([FromBody] DetalleCarritoVM detcar)
        {
            try
            {
                _detalleCarritoService.AddDetCar(detcar);
                return Ok();
            }
            catch (StockInsuficienteException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("get-DetCar-by-carritoid/{id}")]
        public IActionResult GetDetCarByCarID(int id)
        {
            var detcar = _detalleCarritoService.GetDetCarByCarID(id);
            return Ok(detcar);
        }

        [HttpDelete("delete-detallecarrito/{carritoId}/{productoId}")]
        public IActionResult DeleteDetalleCarrito(int carritoId, int productoId)
        {

                _detalleCarritoService.DeleteDetalleCarrito(carritoId, productoId);
                return Ok(new { Message = "El registro ha sido eliminado con éxito." });
        }


    }
}
