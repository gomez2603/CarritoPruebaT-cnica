
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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        [HttpPost]
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
