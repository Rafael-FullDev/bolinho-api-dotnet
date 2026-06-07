using ASP.NET_Core_Web_API.DTOs;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Repositories;

public interface IBolinhoRepository
{
    Task<List<Bolinho>> GetBolinhos(BolinhoFiltroDto filtro);

    Task<Bolinho?> GetIdBolinho(int id);

    Task<Bolinho> CriarBolinho(Bolinho bolinho);

    Task<Bolinho?> AtualizarBolinho(Bolinho bolinho);

    Task<bool> DeleteBolinho(Bolinho bolinho);
}