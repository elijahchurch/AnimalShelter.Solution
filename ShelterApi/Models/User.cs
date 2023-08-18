using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class User
    {
        public int UserId { get; set;}
        [Required]
        public string UserName { get; set;}
        [Required]
        public string Password { get; set;}
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set;}

    }
}