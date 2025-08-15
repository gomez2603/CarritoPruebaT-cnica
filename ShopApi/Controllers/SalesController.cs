using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDomain.Entities;
using ShopService;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _service;
        private readonly IArticuloService _articuloService;

        public SalesController(ISalesService service, IArticuloService articuloService)
        {
            _service = service;
            _articuloService = articuloService;
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("byClient")]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult GetByClient()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null)
                return Unauthorized("No se encontró el ID del usuario en el token");

            int clientId = int.Parse(userIdClaim.Value);
            var data = _service.GetSalesByClient(clientId);
            return Ok(data);
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult Post(Sales articulo)
        {
            try
            {

                _service.Add(articulo);
                return Created($"/api/Articulo/{articulo.Id}", articulo);
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al intentar Crear");
            }


        }


        [HttpPost("multiple")]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult PostMultiple([FromBody] IEnumerable<int> articuloIds)
        {
            try
            {
               
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                if (userIdClaim == null)
                    return Unauthorized("No se encontró el ID del usuario en el token");

                int clientId = int.Parse(userIdClaim.Value);
                var ventas = new List<Sales>();

                foreach (var articuloId in articuloIds)
                {
                  
                    var articulo = _articuloService.FindOne(a => a.Id == articuloId);
                    if (articulo == null)
                        return NotFound($"Artículo con ID {articuloId} no encontrado");

                    if (articulo.Stock <= 0)
                        return BadRequest($"Artículo {articulo.Code} no tiene stock disponible");

                  
                    var sale = new Sales
                    {
                        Id = 0,
                        ClientId = clientId,
                        ArticuloId = articuloId,
                        Fecha = DateTime.Now
                    };

                    _service.Add(sale);

                   
                    articulo.Stock -= 1;
                    _articuloService.Update(articulo);

                    ventas.Add(sale);
                }

               


                return Created("/api/Articulo/", null);
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al intentar crear las ventas: " + ex.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Put(Sales articulo)
        {
            try
            {

                _service.Update(articulo);
                return Created($"/api/Articulo/{articulo.Id}", articulo);
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al intentar Crear");
            }


        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al Intentar Eliminar");
            }


        }
    }
}
