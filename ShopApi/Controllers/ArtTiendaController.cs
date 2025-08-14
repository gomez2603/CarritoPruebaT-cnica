using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Entities;
using ShopService;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtTiendaController : ControllerBase
    {

        private readonly IArtTiendaService _service;
 
        public ArtTiendaController(IArtTiendaService service)
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
        public  IActionResult Post(ArtTienda articulo)
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
        public IActionResult PostMultiple(IEnumerable<ArtTienda> articulo)
        {
            try
            {
                foreach(var element in articulo)
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
        public async Task<IActionResult> Put(ArtTienda articulo)
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
