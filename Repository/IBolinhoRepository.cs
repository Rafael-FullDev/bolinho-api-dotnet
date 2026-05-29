using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Repositories;

public interface IBolinhoRepository
{
    Task<List<bolinho>> GetBolinhos();

    Task<bolinho?> GetIdBolinho(int id);

    Task<bolinho> CriarBolinho(bolinho bolinho);

    Task<bolinho?> AtualizarBolinho(bolinho bolinho);

    Task<bool> DeleteBolinho(bolinho bolinho);
}