using System;

namespace DatingAPI.DTOs
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsMain { get; set; }
    }
}