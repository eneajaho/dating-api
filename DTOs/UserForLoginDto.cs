using System.ComponentModel.DataAnnotations;

namespace DatingAPI.DTOs
{
    public class UserForLoginDto
    {
        [Required] 
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}