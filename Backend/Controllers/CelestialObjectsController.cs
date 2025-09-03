using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelestialObjectsController : ControllerBase
    {

        private readonly ICelestialObjectsService _celestialObjectsService;

        public CelestialObjectsController(ICelestialObjectsService celestialObjectsService) => _celestialObjectsService = celestialObjectsService;

        [HttpPost]
        public async Task<ActionResult> CreateObject([FromForm] CObjectDTO cObjectDTO)
        {

            var cObject = await _celestialObjectsService.CreateObjectAsync(cObjectDTO);

            return Ok(cObject);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllObjects()
        {
            var objects = await _celestialObjectsService.GetAllObjectsAsync();

            return Ok(objects);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateObject(int id, [FromBody] CObjectDTO cObjectDTO)
        {
            var cObject = await _celestialObjectsService.UpdateObjectAsync(id, cObjectDTO);

            return Ok(cObject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteObject(int id)
        {
            await _celestialObjectsService.DeleteObjectAsync(id);

            return Ok();
        }

    }
}
