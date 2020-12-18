using DatingAPI.Helpers;

namespace DatingAPI.Entities.QueryParameters
{
    public class UserParams : QueryStringParameters
    {
        public int UserId { get; set; }
        public string Gender { get; set; }

        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 99;

        public string OrderBy { get; set; }

        public string LastActive { get; set; }
    }
}