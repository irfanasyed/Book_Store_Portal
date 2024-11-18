using System.ComponentModel.DataAnnotations;

namespace Book_Store_Portal.Dto
{
    public class CreateAuthorDto
    {
        [Required]
        public string Author_state {  get; set; }
    }
}
