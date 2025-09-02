namespace Backend;
using System.ComponentModel.DataAnnotations;

public record class CObjectDTO
{
    [Required]
    public string Type { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public DateTime DiscoveredAt { get; set; }
    
    public string? ImageUrl { get; set; }
}
