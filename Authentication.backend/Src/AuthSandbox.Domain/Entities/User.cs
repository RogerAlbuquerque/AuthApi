using System.Text.Json.Serialization;

public sealed class User
{
    public Guid Id { get; } = new Guid();
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }


    public User(string username, string email, string passwordHash)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email is required and cannot be empty or whitespace.", nameof(email));
        if (!email.Contains("@"))
            throw new ArgumentException("Email is invalid", nameof(email));
        if (string.IsNullOrEmpty(passwordHash))
            throw new ArgumentException("Password cannot be empty or whitespace.", nameof(passwordHash));

        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
        Console.WriteLine("Terceiro: " + Username);
    }

    public bool VerifyPassword(string passwordHashToCheck)
    {
        return PasswordHash == passwordHashToCheck;
    }
}