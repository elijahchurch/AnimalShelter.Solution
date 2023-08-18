using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers.v2
{
    [Route("shelterapi/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ShelterApiContext _db;
        public CatsController(ShelterApiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> Get(string name, string gender, string personality, int age, int minAge, int maxAge)
        {
            IQueryable<Cat> catQuery = _db.Cats.AsQueryable();

            if (name != null)
            {
                catQuery = catQuery.Where(entry => entry.Name == name);
            }
            if (gender != null)
            {
                catQuery = catQuery.Where(entry => entry.Gender == gender);
            }
            if (age != 0)
            {
                catQuery = catQuery.Where(entry => entry.Age == age);
            }
            if (minAge > 0)
            {
                catQuery = catQuery.Where(entry => entry.Age >= minAge);
            }
            if (maxAge != 0)
            {
                catQuery = catQuery.Where(entry => entry.Age <= maxAge);
            }
            if(personality !=null)
            {
                catQuery = catQuery.Where(entry => entry.Personality.Contains(personality) == true);
                if( !catQuery.Any())
                {
                    return NotFound();
                }
            }
            return await catQuery.ToListAsync();
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