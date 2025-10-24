// using AuthSandbox.Domain.Interfaces;

using AuthSandbox.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthSandbox.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> Authentication()
    {

        return await _context.Users.ToListAsync();
        
    }

    public async Task<string> Register(string name, string email, string password)
    {
        return await Task.FromResult($"Registro recebido para: {name} com email {email} e password {password}");
    }


}