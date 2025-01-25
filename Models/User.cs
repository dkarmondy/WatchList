namespace WatchList.Models
{
    public class User
    {
        public int Id { get; set; }  // Unique identifier for the user
        public string Username { get; set; }  // Username for login
        public string Email { get; set; }  // User's email
        public string PasswordHash { get; set; }  // Store the password hash for security
        public string Role { get; set; }  // User role (e.g., admin, user, etc.)
        public DateTime CreatedAt { get; set; }  // When the user was created
    }
}
