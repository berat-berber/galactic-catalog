
namespace Backend;

public class CelestialObjectsService : ICelestialObjectsService
{
    private readonly ICelestialObjectsRepository _celestialObjectsRepository;

    public CelestialObjectsService(ICelestialObjectsRepository celestialObjectsRepository) => _celestialObjectsRepository = celestialObjectsRepository;

    public async Task<CObject> CreateObjectAsync(CObjectDTO cObjectDTO)
    {
        var cObject = new CObject()
        {
            Type = cObjectDTO.Type,
            Name = cObjectDTO.Name,
            Description = cObjectDTO.Description,
            DiscoveredAt = cObjectDTO.DiscoveredAt
        };

        return await _celestialObjectsRepository.CreateObjectAsync(cObject);

    }

    public async Task<IEnumerable<CObject>> GetAllObjectsAsync()
    {
        return await _celestialObjectsRepository.GetAllObjectsAsync();
    }

    public async Task<CObject?> UpdateObjectAsync(int id, CObjectDTO cObjectDTO)
    {
        var cObject = await _celestialObjectsRepository.GetObjectByIdAsync(id);

        if (cObject is null) return cObject;

        cObject.Type = cObjectDTO.Type;
        cObject.Name = cObjectDTO.Name;
        cObject.Description = cObjectDTO.Description;

        return await _celestialObjectsRepository.UpdateObjectAsync(cObject);
    }

    public async Task DeleteObjectAsync(int id)
    {
        var cObject = await _celestialObjectsRepository.GetObjectByIdAsync(id);

        if (cObject is null) return;

        await _celestialObjectsRepository.DeleteObjectAsync(cObject);
    }

}
