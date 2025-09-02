namespace Backend;

public interface ICelestialObjectsService
{
    Task<CObject> CreateObjectAsync(CObjectDTO cObjectDTO);

    Task<IEnumerable<CObject>> GetAllObjectsAsync();

    Task<CObject?> UpdateObjectAsync(int id, CObjectDTO cObjectDTO);

    Task DeleteObjectAsync(int id);
}
