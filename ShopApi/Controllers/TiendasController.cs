
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Entities;
using ShopService;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TiendasController : ControllerBase
    {
        private readonly ITiendaService _service;

        public TiendasController(ITiendaService service)
        {
            _service = service;

        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("articulos/{id}")]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public IActionResult GetArticulos(int id)
        {
            return Ok(_service.GetArticulosPorTienda(id));
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Post(Tiendas articulo)
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
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Put(Tiendas articulo)
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
