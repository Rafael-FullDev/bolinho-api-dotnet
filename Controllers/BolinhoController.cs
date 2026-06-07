using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Responses;
using ASP.NET_Core_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("bolinhos")]

    // herdando a controller base na classe Bolinhocontroller
    public class BolinhoController : ControllerBase
    {
        private readonly IBolinhoService _bolinhoService;

        public BolinhoController(IBolinhoService bolinhoService)
        {
            _bolinhoService = bolinhoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBolinhos([FromQuery] BolinhoFiltroDto filtro)
        {
            var bolinhos = await _bolinhoService.GetBolinhos(filtro);

            return Ok(ApiResponse<List<BolinhoResponseDto>>.SucessoResponse(
                bolinhos,
                "Bolinhos listados com sucesso."
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBolinhoId(int id)
        {
            var bolinho = await _bolinhoService.GetIdBolinho(id);

            if (bolinho == null)
            {
                return NotFound(ApiResponse<BolinhoResponseDto>.ErroResponse(
            "Bolinho não encontrado."
        ));
            }

            return Ok(ApiResponse<BolinhoResponseDto>.SucessoResponse(
        bolinho,
        "Bolinho encontrado com sucesso."
    ));
        }

        [HttpPost]
        public async Task<IActionResult> PostBolinho(BolinhoCreateDto dto)
        {
            var bolinho = await _bolinhoService.CriarBolinho(dto);

            return CreatedAtAction(
        nameof(GetBolinhoId),
        new { id = bolinho.Id },
        ApiResponse<BolinhoResponseDto>.SucessoResponse(
            bolinho,
            "Bolinho criado com sucesso."
        )
    );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolinho(int id, BolinhoUpdateDto dto)
        {
            var bolinho = await _bolinhoService.AtualizarBolinho(id, dto);

            if (bolinho == null)
            {
                return NotFound(ApiResponse<BolinhoResponseDto>.ErroResponse(
                    "Bolinho não encontrado."
                ));
            }

            return Ok(ApiResponse<BolinhoResponseDto>.SucessoResponse(
        bolinho,
        "Bolinho atualizado com sucesso."
    ));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolinho(int id)
        {
            var deletado = await _bolinhoService.DeleteBolinho(id);

            if (!deletado)
            {
                return NotFound(ApiResponse<object>.ErroResponse(
                    "Bolinho não encontrado."
                ));
            }

            return Ok(ApiResponse<object>.SucessoResponse(
        null!,
        "Bolinho deletado com sucesso."
    ));
        }
    }
}
