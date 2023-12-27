using Microsoft.AspNetCore.Mvc;
using ODWZ.LB1.Domain.Requests;
using ODWZ.LB1.Domain.Shared;
using ODWZ.LB1.Infrastructure.Interfaces;

namespace ODWZ.LB1.Controllers;

[Route("api/heroes")]
public class HeroController : ControllerBase
{
    private readonly IHeroService _heroService;

    public HeroController(IHeroService heroService)
    {
        _heroService = heroService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHeroes(Pagination pagination)
    {
        return Ok(await _heroService.GetHeroes(pagination));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateHero(CreateHeroRequest request)
    {
        return Ok(await _heroService.CreateHero(request));
    }
}