using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Models
{
    public class ShelterApiContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<User> Users { get; set; }
        public ShelterApiContext(DbContextOptions<ShelterApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dog>()
                .HasData(
                    new Dog { DogId = 1, Name = "Houdini", Gender = "Male", Age = "1y 8m", Personality = "High Energy and Goofy!", HealthSocialNeeds = "Would do best in an environment with older children."},
                    new Dog { DogId = 2, Name = "Jelly Bean", Gender = "Male", Age = "2y 4m", Personality = "Very Social", HealthSocialNeeds = "While not needed, would do better in a home that has another dog for him to play with."},
                    new Dog { DogId = 3, Name = "Farrah", Gender = "Female", Age = "7y", Personality = "Shy and Nervous", HealthSocialNeeds = "Blind. Would do better in an environment with no children"}      
                );
            builder.Entity<Cat>()
                .HasData(
                    new Cat { CatId = 1, Name = "Dinky", Gender = "Female" , Age = "3m", Personality = "Sensitive, shy, worried around new people and environements" , HealthSocialNeeds = "Need time to adjust to new environment."},
                    new Cat { CatId = 2, Name = "Chester", Gender = "Male" , Age =  "2y 3m", Personality = "Affectionate", HealthSocialNeeds = "None." },
                    new Cat { CatId = 3, Name = "Trooper", Gender = "Male", Age = "8y", Personality = "Loud and friendly!" , HealthSocialNeeds = "Deaf. Should be in a home with no other pets."}
                );
            builder.Entity<User>()
                .HasData(
                    new User { UserId = 1, UserName = "TestUser", Password = "Test", EmailAddress = "TestUser@gmail.com"}       
                );
        }
    }
}
