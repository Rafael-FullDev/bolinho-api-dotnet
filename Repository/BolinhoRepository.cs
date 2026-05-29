using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Repositories;

public class BolinhoRepository : IBolinhoRepository
{
    private readonly AppDbContext _appDbContext;

    public BolinhoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<bolinho>> GetBolinhos()
    {
        return await _appDbContext.Bolinhos.ToListAsync();
    }

    public async Task<bolinho?> GetIdBolinho(int id)
    {
        return await _appDbContext.Bolinhos.FindAsync(id);
    }

    public async Task<bolinho> CriarBolinho(bolinho bolinho)
    {
        _appDbContext.Bolinhos.Add(bolinho);

        await _appDbContext.SaveChangesAsync();

        return bolinho;
    }

    public async Task<bolinho?> AtualizarBolinho(bolinho bolinho)
    {
        _appDbContext.Bolinhos.Update(bolinho);

        await _appDbContext.SaveChangesAsync();

        return bolinho;
    }

    public async Task<bool> DeleteBolinho(bolinho bolinho)
    {
        _appDbContext.Bolinhos.Remove(bolinho);

        await _appDbContext.SaveChangesAsync();

        return true;
    }
}