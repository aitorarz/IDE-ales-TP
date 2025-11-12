namespace Music.Models.Auth.User.DTO
{
    public class UserWithoutPassDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<string> Roles { get; set; } = new();
    }
}
