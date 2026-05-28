using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("bolinhos")]

    // herdando a controller base na classe taskcontroller
    public class BolinhoController : ControllerBase
    {
        // criando uma instancia do banco de dados
        private readonly AppDbContext _appDbContext;

        public BolinhoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // consultar os bolinhos do banco de dados e utilizando dto
        [HttpGet]
        public async Task<IActionResult> GetBolinhos()
        {
            var bolinhos = await _appDbContext.Bolinhos
        .Select(b => new BolinhoResponseDto
        {
            Id = b.Id,
            Nome = b.Nome,
            Descricao = b.Descrição,
            Pronto = b.Pronto
        })
        .ToListAsync();
            return Ok(bolinhos);
        }

        // consultar os bolinhos do banco de dados por id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdBolinho()
        {
            var bolinho = await _appDbContext.Bolinhos.ToListAsync();

            if(bolinho == null)
            {
                return BadRequest();
            }

            return Ok(bolinho);
        }

        // criando um bolinho e utilizando dto
        [HttpPost]
        public async Task<IActionResult> CriarBolinho(BolinhoCreateDto dto)
        {
            var Bolinho = new bolinho
            {
                Nome = dto.Nome,
                Descrição = dto.Descricao,
                Pronto = dto.Pronto
            };

            _appDbContext.Bolinhos.Add(Bolinho);

            await _appDbContext.SaveChangesAsync();

            var response = new BolinhoResponseDto
            {
                Id = Bolinho.Id,
                Nome = Bolinho.Nome,
                Descricao = Bolinho.Descrição,
                Pronto = Bolinho.Pronto
            };

            return CreatedAtAction(nameof(GetIdBolinho), new { id = Bolinho.Id }, response);
        }

        // editar um bolinho atraves do id e utilizando dto
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarBolinho(int id, BolinhoUpdateDto dto)
        {
            var bolinho = await _appDbContext.Bolinhos.FindAsync(id);

            if (bolinho == null)
            {
                return NotFound("Bolinho não encontrado.");
            }

            bolinho.Nome = dto.Nome;
            bolinho.Descrição = dto.Descricao;
            bolinho.Pronto = dto.Pronto;

            await _appDbContext.SaveChangesAsync();

            var response = new BolinhoResponseDto
            {
                Id = bolinho.Id,
                Nome = bolinho.Nome,
                Descricao = bolinho.Descrição,
                Pronto = bolinho.Pronto
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolinho(int id)
        {
            var bolinho = await _appDbContext.Bolinhos.FindAsync(id);
            if (bolinho == null)
                return NotFound();
            _appDbContext.Bolinhos.Remove(bolinho);
            await _appDbContext.SaveChangesAsync();
            return Ok(bolinho);
        }

    }
}
