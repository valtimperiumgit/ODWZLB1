using ODWZ.LB1.Domain.Dtos;
using ODWZ.LB1.Domain.Models;
using ODWZ.LB1.Domain.Requests;
using ODWZ.LB1.Domain.Shared;

namespace ODWZ.LB1.Infrastructure.Interfaces;

public interface IHeroService
{
    public Task<PaginationResponse<HeroDto>> GetHeroes(Pagination pagination);
    public Task<HeroDto> CreateHero(CreateHeroRequest request);
}