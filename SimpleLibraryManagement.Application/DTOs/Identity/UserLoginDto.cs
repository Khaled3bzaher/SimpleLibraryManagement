using System.ComponentModel.DataAnnotations;

namespace SimpleLibraryManagement.Application.DTOs.Identity
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
