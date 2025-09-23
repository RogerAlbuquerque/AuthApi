namespace AuthSandbox.Application.Interfaces;
public interface IClientService
{
    Task<string> ClientLogin();
}