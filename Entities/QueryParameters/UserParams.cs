using DatingAPI.Helpers;

namespace DatingAPI.Entities.QueryParameters
{
    public class UserParams : QueryStringParameters
    {
        public int UserId { get; set; }
        public string Gender { get; set; }
    }
}