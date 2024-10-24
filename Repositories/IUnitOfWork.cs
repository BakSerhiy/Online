using Product_Catalog.Properties.Models;

namespace Product_Catalog.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Category> Categories { get; }
    Task<int> CompleteAsync();
}
