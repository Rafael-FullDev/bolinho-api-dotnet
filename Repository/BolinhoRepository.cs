using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.DTOs;
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

    public async Task<List<Bolinho>> GetBolinhos(BolinhoFiltroDto filtro)
    {
        var query = _appDbContext.Bolinhos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtro.Nome))
        {
            query = query.Where(b => b.Nome.Contains(filtro.Nome));
        }

        if (filtro.Pronto.HasValue)
        {
            query = query.Where(b => b.Disponivel == filtro.Pronto.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Bolinho?> GetIdBolinho(int id)
    {
        return await _appDbContext.Bolinhos.FindAsync(id);
    }

    public async Task<Bolinho> CriarBolinho(Bolinho bolinho)
    {
        _appDbContext.Bolinhos.Add(bolinho);

        await _appDbContext.SaveChangesAsync();

        return bolinho;
    }

    public async Task<Bolinho?> AtualizarBolinho(Bolinho bolinho)
    {
        _appDbContext.Bolinhos.Update(bolinho);

        await _appDbContext.SaveChangesAsync();

        return bolinho;
    }

    public async Task<bool> DeleteBolinho(Bolinho bolinho)
    {
        _appDbContext.Bolinhos.Remove(bolinho);

        await _appDbContext.SaveChangesAsync();

        return true;
    }
}