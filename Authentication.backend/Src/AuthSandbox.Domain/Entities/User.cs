public sealed class User
{
    public Guid Id { get; } = new Guid();
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    public User(string email, string passwordHash)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email is required and cannot be empty or whitespace.", nameof(email));
        if (!email.Contains("@"))
            throw new ArgumentException("Email is invalid", nameof(email));            
        if (string.IsNullOrEmpty(passwordHash))
            throw new ArgumentException("Password cannot be empty or whitespace.", nameof(passwordHash));

        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
}