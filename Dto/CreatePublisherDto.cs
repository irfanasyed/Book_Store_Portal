using System.ComponentModel.DataAnnotations;

namespace Book_Store_Portal.Dto
{
    public class CreatePublisherDto
    {
        [Required]
        public string? PubName { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? State { get; set; }

        [Required]
        public string? Country { get; set; }
    }
}
