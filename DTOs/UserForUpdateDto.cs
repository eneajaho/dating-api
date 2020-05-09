using System;

namespace DatingAPI.DTOs
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string KnownAs { get; set; }
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}