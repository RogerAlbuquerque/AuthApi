public interface IClientRepository
{
    Task<IEnumerable<User>> Authentication();  
    Task<User> Register();  
}