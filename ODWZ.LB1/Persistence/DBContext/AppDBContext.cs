using Microsoft.EntityFrameworkCore;
using ODWZ.LB1.Domain.Models;

namespace ODWZ.LB1.Persistence.DBContext;

public class AppDbContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }

    public DbSet<Class> Classes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}