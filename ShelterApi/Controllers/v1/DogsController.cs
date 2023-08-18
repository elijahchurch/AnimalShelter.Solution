using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers.v1
{
    [Route("shelterapi/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    // [ApiVersion("2.0")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly ShelterApiContext _db;
        public DogsController(ShelterApiContext db)
        {
            _db = db;
        }

        // [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> Get()
        {
            return await _db.Dogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            Dog dog = await _db.Dogs.FindAsync(id);
            if ( dog == null)
            {
                return NotFound();
            }
            return dog;
        }

        [HttpPost]
        public async Task<ActionResult<Dog>> Post(Dog dog)
        {
            _db.Dogs.Add(dog);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDog), new { id = dog.DogId}, dog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dog dog)
        {
            if (id != dog.DogId)
            {
                return BadRequest();
            }
            _db.Dogs.Update(dog);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
                {
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            Dog dog = await _db.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            _db.Dogs.Remove(dog);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        private bool DogExists(int id)
        {
            return _db.Dogs.Any(entry => entry.DogId == id);
        }
    }
}