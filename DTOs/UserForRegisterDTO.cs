using System;
using System.ComponentModel.DataAnnotations;

namespace DatingAPI.DTOs
{
    public class UserForRegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]    
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required] public string Gender { get; set; }
        [Required] public DateTime Birthday { get; set; }
        [Required] public string KnownAs { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }

        public UserForRegisterDto()
        {
            CreatedAt = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}