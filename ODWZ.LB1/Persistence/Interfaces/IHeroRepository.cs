
using ODWZ.LB1.Domain.Models;
using ODWZ.LB1.Domain.Shared;

namespace ODWZ.LB1.Persistence.Interfaces;

public interface IHeroRepository
{
    public Task<List<Hero>> GetHeroes(Pagination pagination);
    public Task<int> CountHeroes();
    public Task CreateHero(Hero hero);
}