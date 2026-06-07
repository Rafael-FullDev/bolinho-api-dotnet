using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Mappings;
using ASP.NET_Core_Web_API.Repositories;

namespace ASP.NET_Core_Web_API.Services;

public class BolinhoService : IBolinhoService
{
    private readonly IBolinhoRepository _bolinhoRepository;

    public BolinhoService(IBolinhoRepository bolinhoRepository)
    {
        _bolinhoRepository = bolinhoRepository;
    }

    // consultar os bolinhos do banco de dados e utilizando dto
    public async Task<List<BolinhoResponseDto>> GetBolinhos(BolinhoFiltroDto filtro)
    {
        var bolinhos = await _bolinhoRepository.GetBolinhos(filtro);

        return BolinhoMapper.ToResponseDtoList(bolinhos);
    }

    // consultar os bolinhos do banco de dados por id
    public async Task<BolinhoResponseDto> GetIdBolinho(int id)
    {
        var bolinho = await _bolinhoRepository.GetIdBolinho(id);

        if (bolinho == null)
        {
            return null;
        }

        return BolinhoMapper.ToResponseDto(bolinho);
    }

    // criando um bolinho e utilizando dto
    public async Task<BolinhoResponseDto> CriarBolinho(BolinhoCreateDto dto)
    {
        var bolinho = BolinhoMapper.ToModel(dto);

        var bolinhoCriado = await _bolinhoRepository.CriarBolinho(bolinho);

        return BolinhoMapper.ToResponseDto(bolinhoCriado);
    }

    // editar um bolinho atraves do id e utilizando dto
    public async Task<BolinhoResponseDto> AtualizarBolinho(int id, BolinhoUpdateDto dto)
    {
        var bolinho = await _bolinhoRepository.GetIdBolinho(id);

        if (bolinho == null)
        {
            return null;
        }

        BolinhoMapper.UpdateModel(bolinho, dto);

        var bolinhoAtualizado = await _bolinhoRepository.AtualizarBolinho(bolinho);

        return BolinhoMapper.ToResponseDto(bolinhoAtualizado!);
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