using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers
{
    [Route("shelterapi/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShelterApiContext _db;
        public UsersController(ShelterApiContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}