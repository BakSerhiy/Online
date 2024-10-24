using Product_Catalog.Data;
using Product_Catalog.Properties.Models;

namespace Product_Catalog.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductCatalogContext _context;

    public UnitOfWork(ProductCatalogContext context)
    {
        _context = context;
        Products = new GenericRepository<Product>(_context);
        Categories = new GenericRepository<Category>(_context);
    }

    public IGenericRepository<Product> Products { get; private set; }
    public IGenericRepository<Category> Categories { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
