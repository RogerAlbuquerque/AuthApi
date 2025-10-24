using AuthSandbox.Application.Interfaces;
namespace AuthSandbox.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<IEnumerable<User>> ClientLogin(string email, string password)
    {
        var res = await _clientRepository.Authentication();
        return res;
    }

    public async Task<User> ClientRegister(string name, string email, string password)
    {
        User res = await _clientRepository.Register(name, email, password);
        return res;
    }
}