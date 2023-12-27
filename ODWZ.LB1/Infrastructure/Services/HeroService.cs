using ODWZ.LB1.Domain.Dtos;
using ODWZ.LB1.Domain.Models;
using ODWZ.LB1.Domain.Requests;
using ODWZ.LB1.Domain.Shared;
using ODWZ.LB1.Infrastructure.Interfaces;
using ODWZ.LB1.Persistence.Interfaces;

namespace ODWZ.LB1.Infrastructure.Services;

public class HeroService : IHeroService
{
    private readonly IHeroRepository _heroRepository;
    private readonly IClassRepository _classRepository;

    public HeroService(IHeroRepository heroRepository, IClassRepository classRepository)
    {
        _heroRepository = heroRepository;
        _classRepository = classRepository;
    }

    public async Task<PaginationResponse<HeroDto>> GetHeroes(Pagination pagination)
    {
        var heroes = await _heroRepository.GetHeroes(pagination);
        
        return new PaginationResponse<HeroDto>
        {
            Items = heroes.Select(hero => new HeroDto(hero)).ToList(),
            CurrentPage = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalItems = await _heroRepository.CountHeroes()
        };
    }

    public async Task<HeroDto> CreateHero(CreateHeroRequest request)
    {
        var heroClass = await _classRepository.GetClassById(request.ClassId);

        if (heroClass is null)
        {
            throw new ArgumentException("Class invalid");
        }

        var hero = new Hero
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ClassId = request.ClassId,
            Class = heroClass
        };

        using var memoryStream = new MemoryStream();
        await request.Image.CopyToAsync(memoryStream);
        hero.Image = memoryStream.ToArray();

        await _heroRepository.CreateHero(hero);

        return new HeroDto(hero);
    }
}