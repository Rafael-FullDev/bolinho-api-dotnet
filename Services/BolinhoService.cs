using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Services;

public class BolinhoService : IBolinhoService
{
    // criando uma instancia do banco de dados
    private readonly IBolinhoRepository _bolinhoRepository;

    public BolinhoService(IBolinhoRepository bolinhoRepository)
    {
        _bolinhoRepository = bolinhoRepository;
    }

    // consultar os bolinhos do banco de dados e utilizando dto
    public async Task<List<BolinhoResponseDto>> GetBolinhos()
    {
        var bolinhos = await _bolinhoRepository.GetBolinhos();

        return bolinhos.Select(b => new BolinhoResponseDto
        {
            Id = b.Id,
            Nome = b.Nome,
            Descricao = b.Descrição,
            Pronto = b.Pronto
        }).ToList();
    }

    // consultar os bolinhos do banco de dados por id
    public async Task<BolinhoResponseDto> GetIdBolinho(int id)
    {
        var bolinho = await _bolinhoRepository.GetIdBolinho(id);

        if (bolinho == null)
        {
            return null;
        }

        return new BolinhoResponseDto
        {
            Id = bolinho.Id,
            Nome = bolinho.Nome,
            Descricao = bolinho.Descrição,
            Pronto = bolinho.Pronto
        };
    }

    // criando um bolinho e utilizando dto
    public async Task<BolinhoResponseDto> CriarBolinho(BolinhoCreateDto dto)
    {
        var Bolinho = new bolinho
        {
            Nome = dto.Nome,
            Descrição = dto.Descricao,
            Pronto = dto.Pronto
        };

        var bolinhoCriado = await _bolinhoRepository.CriarBolinho(Bolinho);

        return new BolinhoResponseDto
        {
            Id = Bolinho.Id,
            Nome = Bolinho.Nome,
            Descricao = Bolinho.Descrição,
            Pronto = Bolinho.Pronto
        };
    }

    // editar um bolinho atraves do id e utilizando dto
    public async Task<BolinhoResponseDto> AtualizarBolinho(int id, BolinhoUpdateDto dto)
    {
        var bolinho = await _bolinhoRepository.GetIdBolinho(id);

        if (bolinho == null)
        {
            return null;
        }

        bolinho.Nome = dto.Nome;
        bolinho.Descrição = dto.Descricao;
        bolinho.Pronto = dto.Pronto;

        var bolinhoAtualizado = await _bolinhoRepository.AtualizarBolinho(bolinho);

        return new BolinhoResponseDto
        {
            Id = bolinho.Id,
            Nome = bolinho.Nome,
            Descricao = bolinho.Descrição,
            Pronto = bolinho.Pronto
        };
    }

    public async Task<bool> DeleteBolinho(int id)
    {
        var bolinho = await _bolinhoRepository.GetIdBolinho(id);

        if (bolinho == null)
            return false;

        await _bolinhoRepository.DeleteBolinho(bolinho);

        return true;
    }

}