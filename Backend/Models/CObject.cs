namespace Backend;

[Table("c_objects")]
public class CObject
{
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public string Type { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("discovered_at")]
    public DateTime DiscoveredAt { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; }
}
