using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class Cat
    {
        public int CatId { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Gender { get; set;}
        [Required]
        public string Age { get; set;}
        [Required]
        public string Personality { get; set;}
        public string HealthSocialNeeds { get; set;}
    }
}