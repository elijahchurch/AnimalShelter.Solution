using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Models
{
    public class ShelterApiContext : DbContext
    {
        public DbSet<Cat> Cats { get; set;}
        public DbSet<Dog> Dogs { get; set;}
        public DbSet<User> Users { get; set;}
        public ShelterApiContext(DbContextOptions<ShelterApiContext> options) : base(options)
        {
            
        }
    }
}
