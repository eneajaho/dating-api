using System;
using System.ComponentModel.DataAnnotations;

namespace DatingAPI.Entities.DTOs
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            CreatedAt = DateTime.Now;
            LastActive = DateTime.Now;
        }

        [Required] 
        [StringLength(20, ErrorMessage = "Username cannot be longer than 20 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 30 characters")]
        public string Password { get; set; }

        [Required] public string Gender { get; set; }
        [Required] public DateTime Birthday { get; set; }
        [Required] public string KnownAs { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
    }
}