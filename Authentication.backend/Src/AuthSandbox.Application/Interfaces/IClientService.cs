namespace AuthSandbox.Application.Interfaces;
public interface IClientService
{
    Task<IEnumerable<User>> ClientLogin(string email, string password);
    Task<User> ClientRegister(string name, string email, string password);
}