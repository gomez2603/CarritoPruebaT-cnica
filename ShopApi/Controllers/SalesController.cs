using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Entities;
using ShopService;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _service;

        public SalesController(ISalesService service)
        {
            _service = service;

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


        [HttpPost("Multiple")]
        [Authorize(Roles = "ADMIN,CLIENT")]
        public  IActionResult PostMultiple(IEnumerable<Sales> articulo)
        {
            try
            {
                foreach (var element in articulo)
                {
                    _service.Add(element);
                }

                return Created($"/api/Articulo/", articulo);
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al intentar Crear");
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
