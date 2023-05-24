using BackendSiteVendas.Domain.Entities.Product;
using BackendSiteVendas.Domain.Repositories.Product.Category;
using Microsoft.EntityFrameworkCore;

namespace BackendSiteVendas.Infrastructure.RepositoryAccess.Repository;

public class CategoryRepository : ICategoryWriteOnlyRepository
{
    private readonly BackendSiteVendasContext _context;

    public CategoryRepository(BackendSiteVendasContext context)
    {
        _context = context;
    }

    public async Task Register(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task Delete(long categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        _context.Categories.Remove(category);
    }    
}
