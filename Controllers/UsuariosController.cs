using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioServices.ObtenerUsuarios();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> ObtenerUnUsuario(int id)
        {
            var result = await _usuarioServices.ObtenerUsuario(id);

            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CrearUsuario([FromBody]UsuarioDto usuarioDto)
        {
            var result = await _usuarioServices.CrearUsuario(usuarioDto);
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> ActualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var result = await _usuarioServices.ActualizarUsuario(id, usuarioDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> BorrarUsuario(int id)
        {
            var result = await _usuarioServices.BorrarUsuario(id);
            return Ok(result);
        }
    }
}
