using ASP.NET_Core_Web_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("tasks")]

    // herdando a controller base na classe taskcontroller
    public class BolinhoController : ControllerBase
    {
        // criando uma lista de bolinhos
        private static List<bolinho> bolinhos = new List<bolinho>();

        // consultar os dados da lista
        [HttpGet]
        public IActionResult GetBolinhos(){
            return Ok(bolinhos);
    }
        // adicionar um bolinho na lista
        [HttpPost]
        public IActionResult CreateBolinho(bolinho bolinho)
        {
            bolinhos.Add(bolinho);
            return Ok(bolinhos);
        }

        // editar um bolinho atraves do id
        [HttpPut("{id}")]
        public IActionResult UpdateBolinho(int id, bolinho updatedBolinho)
        {
            var bolinho = bolinhos.FirstOrDefault(b => b.Id == id);
            if (bolinho == null)
                return NotFound();
            bolinho.Nome = updatedBolinho.Nome;
            bolinho.Descrição = updatedBolinho.Descrição;
            bolinho.Pronto = updatedBolinho.Pronto;

            return Ok(bolinho);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBolinho(int id)
        {
            var bolinho = bolinhos.FirstOrDefault(b => b.Id == id);

            if (bolinho is null)
                return NotFound();
            bolinhos.Remove(bolinho);

            return Ok(bolinho);
        }
    }
}
