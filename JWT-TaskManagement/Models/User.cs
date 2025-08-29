namespace JWT_TaskManagement.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // 👈 Add this
        public string Role { get; set; } = "User";           // Default role
    }
}
