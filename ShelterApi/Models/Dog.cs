using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class Dog
    {
        public int DogId { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Gender { get; set;}
        [Required]
        public int Age { get; set;}
        [Required]
        public string Personality { get; set;}
        public string HealthSocialNeeds { get; set;}
    }
}