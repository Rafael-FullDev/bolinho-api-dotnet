using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Bolinho> Bolinhos { get; set; }
}