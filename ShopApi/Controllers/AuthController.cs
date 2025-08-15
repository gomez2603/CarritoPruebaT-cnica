using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDomain.Dtos;
using ShopDomain.Entities;
using ShopService;
using ShopService.Implentation;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public AuthController(IAuthService authService, IMapper mapper, IClienteService clienteService)
        {
            _authService = authService;
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginDto user)
        {
            var usertoLogin = _clienteService.FindOne(x => x.Username == user.username);
            if (usertoLogin == null)
            {
                return NotFound();
            }
            if (_authService.VerifyPassword(user.password, usertoLogin.PasswordHash, usertoLogin.PasswordSalt))
            {
                var response = _mapper.Map<LoginResponseDto>(usertoLogin);
                response.token = _authService.CreateToken(usertoLogin);
                return Ok(response);
            }

            return BadRequest("Usuario o Contraseña Incorrecta");

        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAll()
        {
            var map = _mapper.Map<IEnumerable<userResponseDto>>(_clienteService.GetAll().ToList());
            return Ok(map);
        }


        [HttpPost("Register")]
        public IActionResult Add([FromBody] RegisterDto user)
        {
            var map = _mapper.Map<Clientes>(user);
            _authService.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            map.PasswordHash = passwordHash;
            map.PasswordSalt = passwordSalt;

            try
            {
                _clienteService.Add(map);
                var response = _mapper.Map<userResponseDto>(map);

                return Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest("El nombre de usuario ya esta en uso");
            }
        }
    }
}
