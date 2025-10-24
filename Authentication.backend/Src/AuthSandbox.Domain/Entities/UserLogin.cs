
public sealed class UserLogin
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public UserLogin(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

}