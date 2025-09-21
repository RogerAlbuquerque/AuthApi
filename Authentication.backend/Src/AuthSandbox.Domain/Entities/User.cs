public sealed class User
{
    public User()
    {
        // Id = Guid.NewGuid();
        // CreatedAt = DateTime.UtcNow;
        // UpdatedAt = DateTime.UtcNow;
    }
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}