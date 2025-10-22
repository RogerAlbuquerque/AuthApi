using AuthSandbox.Application.Interfaces;
namespace AuthSandbox.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<IEnumerable<User>> ClientLogin()
    {
        var res = await _clientRepository.Authentication();
        return res;
    }

}