using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Dtos;
using ShopDomain.Entities;
using ShopService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class ArticuloController : ControllerBase
    {

        private readonly IArticuloService _service;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        public ArticuloController(IArticuloService service, Cloudinary cloudinary,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _cloudinary = cloudinary;
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
        public async Task<IActionResult> Post(CreateUpdateArticulo articulo)
        {
            try
            {
                var data = this._mapper.Map<Articulo>(articulo);
                if (articulo.Image != null)
                {
                  
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(articulo.Code, articulo.Image.OpenReadStream()),
                        AssetFolder = "Products"

                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    data.Image = uploadResult.SecureUrl.ToString();
                }
                
                _service.Add(data);
                return Created($"/api/Articulo/{data.Id}", data);
            }
            catch (Exception ex)
            {
                return BadRequest("Fallo al intentar Crear");
            }


        }
        [HttpPut]
        public async Task<IActionResult> Put(CreateUpdateArticulo articulo)
        {
            try
            {
                var data = this._mapper.Map<Articulo>(articulo);
                if (articulo.Image != null)
                {

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(articulo.Code, articulo.Image.OpenReadStream()),
                        AssetFolder = "Products"

                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    data.Image = uploadResult.SecureUrl.ToString();
                }
                _service.Update(data);
                return Created($"/api/Articulo/{data.Id}", data);
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
