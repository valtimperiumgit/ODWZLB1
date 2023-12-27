using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ODWZ.LB1.Domain.Models;
using ODWZ.LB1.Domain.Shared;
using ODWZ.LB1.Persistence.DBContext;
using ODWZ.LB1.Persistence.Interfaces;

namespace ODWZ.LB1.Persistence.Repositories;

public class HeroRepository : BaseRepository, IHeroRepository
{
    public HeroRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task<List<Hero>> GetHeroes(Pagination pagination)
    {
        var query = AppDbContext.Heroes.AsQueryable();
        
        if (!string.IsNullOrEmpty(pagination.OrderBy))
        {
            query = GetQueryByOrdering(pagination);
        }
        
        return query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
    }

    public Task<int> CountHeroes()
    {
        return AppDbContext.Heroes.CountAsync();
    }

    public async Task CreateHero(Hero hero)
    {
        await AppDbContext.Heroes.AddAsync(hero);
        await AppDbContext.SaveChangesAsync();
    }

    private IQueryable<Hero> GetQueryByOrdering(Pagination pagination)
    {
        var query = AppDbContext.Heroes.Include(h => h.Class).AsQueryable();
        
        var propertyInfo = typeof(Hero).GetProperty(
            pagination.OrderBy,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Instance);
        
        if (propertyInfo == null)
        {
            return query;
        }
        
        query = pagination.Ascending ? 
            query.OrderBy(x => EF.Property<object>(x, pagination.OrderBy))
            : query.OrderByDescending(x => EF.Property<object>(x, pagination.OrderBy));

        return query;
    }
}