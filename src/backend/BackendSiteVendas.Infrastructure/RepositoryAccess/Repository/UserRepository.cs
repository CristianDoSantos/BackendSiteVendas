using BackendSiteVendas.Domain.Entities;
using BackendSiteVendas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess.Repository;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly BackendSiteVendasContext _context;
    
    public UserRepository(BackendSiteVendasContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> UserHasEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email));
    }
}