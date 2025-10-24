public interface IClientRepository
{
    Task<IEnumerable<User>> Authentication();  
    Task<string> Register(string name, string email, string password);  
}