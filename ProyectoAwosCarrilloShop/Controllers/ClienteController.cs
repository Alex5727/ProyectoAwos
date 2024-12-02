using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAwosCarrilloShop.Data.Services;
using ProyectoAwosCarrilloShop.Data.ViewModels;

namespace ProyectoAwosCarrilloShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ClienteService _clienteservice;

        public ClienteController(ClienteService clienteservice)
        {
            _clienteservice = clienteservice;
        }


        [HttpGet("get-all-Clientes")]
        public IActionResult GetAllClt()
        {
            var allbooks = _clienteservice.GetAllClt();
            return Ok(allbooks);
        }

        [HttpPost("add-Cliente")]
        public IActionResult AddCliente([FromBody] ClienteVM cliente)
        {
            _clienteservice.AddCliente(cliente);
            return Ok();
        }

        [HttpGet("get-cliente-by-id/{id}")]
        public IActionResult GetClienteByID(int id)
        {
            var cliente = _clienteservice.GetClienteByID(id);
            return Ok(cliente);
        }

        [HttpDelete("delete-cliente-by-id/{id}")]
        public IActionResult DeleteClienteByID(int id)
        {
            _clienteservice.DeleteClienteByID(id);
            return Ok();
        }

    }
}
