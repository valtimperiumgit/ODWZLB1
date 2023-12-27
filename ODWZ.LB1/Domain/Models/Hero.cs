namespace ODWZ.LB1.Domain.Models;

public class Hero
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public byte[] Image { get; set; }
    
    public decimal Price { get; set; }
    
    public int ClassId { get; set; }
    
    public Class Class { get; set; }
}