namespace Backend;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


[Table("c_objects")]
public class CObject
{
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("discovered_at")]
    public DateTime DiscoveredAt { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }
}
