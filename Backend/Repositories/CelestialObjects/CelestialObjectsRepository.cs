
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class CelestialObjectsRepository : ICelestialObjectsRepository
{
    private readonly AppDbContext _context;

    public CelestialObjectsRepository(AppDbContext context) => _context = context;

    public async Task<CObject> CreateObjectAsync(CObject cObject)
    {
        await _context.CObjects.AddAsync(cObject);
        await _context.SaveChangesAsync();

        return cObject;
    }

    public async Task<IEnumerable<CObject>> GetAllObjectsAsync()
    {
        var objects = await _context.CObjects.ToListAsync();

        return objects;
    }

    public async Task<CObject?> UpdateObjectAsync(CObject cObject)
    {
        _context.CObjects.Update(cObject);
        await _context.SaveChangesAsync();

        return cObject;
    }
    public async Task DeleteObjectAsync(CObject cObject)
    {
        _context.CObjects.Remove(cObject);
        await _context.SaveChangesAsync();

        return;
    }

    public async Task<CObject?> GetObjectByIdAsync(int id)
    {
        return await _context.CObjects.FirstOrDefaultAsync(u => u.Id == id);
    }
}
