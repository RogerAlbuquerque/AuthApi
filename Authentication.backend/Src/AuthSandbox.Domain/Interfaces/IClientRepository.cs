public interface IClientRepository
{
    Task<IEnumerable<User>> Authentication();  
    Task<User> Register(string name, string email, string password);  
}