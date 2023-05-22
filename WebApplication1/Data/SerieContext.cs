using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class SerieContext : DbContext
{
    public SerieContext(DbContextOptions<SerieContext> opts)
        : base(opts)
    
    {

    }

    public DbSet<Serie> Series { get; set; }
    
}