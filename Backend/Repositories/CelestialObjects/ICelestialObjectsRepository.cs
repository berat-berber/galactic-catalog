using System.Collections;

namespace Backend;

public interface ICelestialObjectsRepository
{
    Task<CObject> CreateObjectAsync(CObject cObject);

    Task<IEnumerable<CObject>> GetAllObjectsAsync();
    Task<CObject?> GetObjectByIdAsync(int id);

    Task<CObject?> UpdateObjectAsync(CObject cObject);

    Task DeleteObjectAsync(CObject cObject);
}
