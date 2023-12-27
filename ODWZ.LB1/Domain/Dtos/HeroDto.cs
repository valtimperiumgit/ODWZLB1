using ODWZ.LB1.Domain.Models;

namespace ODWZ.LB1.Domain.Dtos;

public class HeroDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ImageBase64 { get; set; }
    
    public decimal Price { get; set; }
    
    public string ClassName { get; set; }
    
    public HeroDto(Hero hero)
    {
        if (hero == null)
        {
            throw new ArgumentNullException(nameof(hero));
        }

        Id = hero.Id;
        Name = hero.Name;
        Description = hero.Description;
        ImageBase64 = Convert.ToBase64String(hero.Image);
        Price = hero.Price;
        ClassName = hero.Class.Name;
    }
}