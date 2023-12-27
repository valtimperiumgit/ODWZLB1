using System.ComponentModel.DataAnnotations;

namespace ODWZ.LB1.Domain.Requests;

public class CreateHeroRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(200, ErrorMessage = "Description length cannot exceed 200 characters.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Image is required.")]
    public IFormFile Image { get; set; }
    
    [Required(ErrorMessage = "Price is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "ClassId is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Class must be a positive value.")]
    public int ClassId { get; set; }
}