using BackendSiteVendas.Domain.Entities;
using BackendSiteVendas.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess.Repository;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
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

    public async Task<User> RetrieveByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<User> RetrieveByEmailAndPassword(string email, string password)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public async Task<bool> UserHasEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email));
    }
}