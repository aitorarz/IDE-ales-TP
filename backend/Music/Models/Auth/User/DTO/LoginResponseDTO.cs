namespace Music.Models.Auth.User.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = null!;

        public UserWithoutPassDTO User { get; set; } = null!;
    }
}
