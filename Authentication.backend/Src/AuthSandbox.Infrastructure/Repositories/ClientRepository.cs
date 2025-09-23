// using AuthSandbox.Domain.Interfaces;

namespace AuthSandbox.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    public async Task<string> ClientAuthentication()
    {
        await Task.Delay(2000);
        return "Client Repository is working!";
    }
}