using ASP.NET_Core_Web_API.DTOs;

namespace ASP.NET_Core_Web_API.Services;

public interface IBolinhoService
{
    Task<List<BolinhoResponseDto>> GetBolinhos();

    Task<BolinhoResponseDto?> GetIdBolinho(int id);

    Task<BolinhoResponseDto> CriarBolinho(BolinhoCreateDto dto);

    Task<BolinhoResponseDto?> AtualizarBolinho(int id, BolinhoUpdateDto dto);

    Task<bool> DeleteBolinho(int id);
}