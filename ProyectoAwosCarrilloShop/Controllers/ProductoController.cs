using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAwosCarrilloShop.Data.Services;
using ProyectoAwosCarrilloShop.Data.ViewModels;

namespace ProyectoAwosCarrilloShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        public ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet("get-all-Productos")]
        public IActionResult GetAllProductos()
        {
            var allbooks = _productoService.GetAllProductos();
            return Ok(allbooks);
        }

        [HttpPost("add-Producto")]
        public IActionResult AddProducto([FromBody] ProductoVM producto)
        {
            _productoService.AddProducto(producto);
            return Ok();
        }


        [HttpGet("get-producto-by-id/{id}")]
        public IActionResult GetProductByID(int id)
        {
            var producto = _productoService.GetProductByID(id);
            return Ok(producto);
        }

        [HttpGet("get-precioproducto-by-id/{id}")]
        public IActionResult GetProductPriceByID(int id)
        {
            var producto = _productoService.GetProductPriceByID(id);
            return Ok(producto);
        }


        [HttpPut("update-producto.by-id/{id}")]
        public IActionResult UpdateProductoById(int id, ProductoVM producto)
        {
            var updateProducto = _productoService.UpdateProductByID(id, producto);
            return Ok(updateProducto);
        }

        [HttpDelete("delete-producto-by-id/{id}")]
        public IActionResult DeleteProductoByID(int id)
        {
            _productoService.DeleteProductoByID(id);
            return Ok();
        }

    }
}
