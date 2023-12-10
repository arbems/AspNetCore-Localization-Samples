using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The Name field cannot be more than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field does not have a valid format.")]
        public string Email { get; set; }
    }
}
