namespace Backend;

public record class CObjectDTO
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DiscoveredAt { get; set; }
    public string ImageUrl { get; set; }
}
