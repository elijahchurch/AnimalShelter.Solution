using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers
{
    [Route("shelterapi/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ShelterApiContext _db;
        public CatsController(ShelterApiContext db)
        {
            _db = db;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> Get()
        {
            return await _db.Cats.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            Cat cat = await _db.Cats.FindAsync(id);
            if ( cat == null)
            {
                return NotFound();
            }
            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<Cat>> Post(Cat cat)
        {
            _db.Cats.Add(cat);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCat), new { id = cat.CatId}, cat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cat cat)
        {
            if (id != cat.CatId)
            {
                return BadRequest();
            }
            _db.Cats.Update(cat);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
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
        public async Task<IActionResult> DeleteCat(int id)
        {
            Cat cat = await _db.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Cats.Remove(cat);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        private bool CatExists(int id)
        {
            return _db.Cats.Any(entry => entry.CatId == id);
        }
    }
}