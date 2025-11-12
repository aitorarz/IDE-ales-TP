using System.ComponentModel.DataAnnotations;

namespace Music.Models.Auth.User.DTO
{
    public class LoginDTO
    {
        [Required]
        [MinLength(2)]
        public string EmailOrUsername { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}
