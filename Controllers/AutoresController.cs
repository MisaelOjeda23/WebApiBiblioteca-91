using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices) 
        {
            _autorServices = autorServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetAutores()
        {
            var result = await _autorServices.GetAutores();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAutor([FromBody] AutorDto autor)
        {
            var result = await _autorServices.CreateAutor(autor);
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAutor(int id, Autor autor)
        {
            var result = await _autorServices.UpdateAutor(id, autor);
            return Ok(result);
        }

        [HttpDelete("{idAutor}")]

        public async Task<IActionResult> DeleteAutor(int idAutor)
        {
            var result = await _autorServices.DeleteAutor(idAutor);
            return Ok(result);
        }
    }
}
