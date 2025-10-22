namespace AuthSandbox.Application.Interfaces;
public interface IClientService
{
    Task<IEnumerable<User>> ClientLogin();
}