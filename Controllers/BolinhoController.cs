using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("bolinhos")]

    // herdando a controller base na classe taskcontroller
    public class BolinhoController : ControllerBase
    {
        private readonly IBolinhoService _bolinhoService;

        public BolinhoController(IBolinhoService bolinhoService)
        {
            _bolinhoService = bolinhoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarBolinhos()
        {
            var bolinhos = await _bolinhoService.GetBolinhos();

            return Ok(bolinhos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdBolinho(int id)
        {
            var bolinho = await _bolinhoService.GetIdBolinho(id);

            if (bolinho == null)
            {
                return NotFound("Bolinho não encontrado.");
            }

            return Ok(bolinho);
        }

        [HttpPost]
        public async Task<IActionResult> CriarBolinho(BolinhoCreateDto dto)
        {
            var bolinho = await _bolinhoService.CriarBolinho(dto);

            return CreatedAtAction(nameof(GetIdBolinho), new { id = bolinho.Id }, bolinho);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarBolinho(int id, BolinhoUpdateDto dto)
        {
            var bolinho = await _bolinhoService.AtualizarBolinho(id, dto);

            if (bolinho == null)
            {
                return NotFound("Bolinho não encontrado.");
            }

            return Ok(bolinho);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolinho(int id)
        {
            var deletado = await _bolinhoService.DeleteBolinho(id);

            if (!deletado)
            {
                return NotFound("Bolinho não encontrado.");
            }

            return NoContent();
        }
    }
}
