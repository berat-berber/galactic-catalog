namespace Backend;
using Microsoft.EntityFrameworkCore;

public class AppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CObject> CObjects { get; set; }
}
