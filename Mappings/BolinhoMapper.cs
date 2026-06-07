using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Mappings;

public static class BolinhoMapper
{
    public static Bolinho ToModel(BolinhoCreateDto dto)
    {
        return new Bolinho
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Disponivel = dto.Pronto,
            Categoria = dto.Categoria,
            ImagemUrl = dto.ImagemUrl
        };
    }

    public static void UpdateModel(Bolinho bolinho, BolinhoUpdateDto dto)
    {
        bolinho.Nome = dto.Nome;
        bolinho.Descricao = dto.Descricao;
        bolinho.Disponivel = dto.Pronto;
        bolinho.Categoria = dto.Categoria;
        bolinho.ImagemUrl = dto.ImagemUrl;
    }

    public static BolinhoResponseDto ToResponseDto(Bolinho bolinho)
    {
        return new BolinhoResponseDto
        {
            Id = bolinho.Id,
            Nome = bolinho.Nome,
            Descricao = bolinho.Descricao,
            Pronto = bolinho.Disponivel,
            Categoria = bolinho.Categoria,
            ImagemUrl = bolinho.ImagemUrl
        };
    }

    public static List<BolinhoResponseDto> ToResponseDtoList(List<Bolinho> bolinhos)
    {
        return bolinhos.Select(b => ToResponseDto(b)).ToList();
    }
}