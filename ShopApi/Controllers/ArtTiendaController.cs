using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Dtos;
using ShopDomain.Entities;
using ShopService;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class ArtTiendaController : ControllerBase
    {

        private readonly IArtTiendaService _service;
        private readonly IMapper _mapper;
        public ArtTiendaController(IArtTiendaService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        
        }
        [HttpGet]
        public IActionResult GetAll()
            
        {
            var map = _mapper.Map<IEnumerable<ArtTIendaResponse>>(_service.GetAll(incluirPropiedades: "Tiendas,Articulo"));
            return Ok(map);
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
