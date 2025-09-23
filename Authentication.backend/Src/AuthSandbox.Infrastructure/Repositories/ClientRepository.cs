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
    public async Task<IEnumerable<User>> ClientAuthentication()
    {

        return await _context.Users.ToListAsync();
        
    }
}