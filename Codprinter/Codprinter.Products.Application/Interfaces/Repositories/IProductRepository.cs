using Codprinter.Products.Application.POCOs;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Products.Application.Interfaces.Repositories;

public interface IProductRepository : IUnitOfWork
{
    Task AddAsync(Product product);
    Task<bool> ExistsAsync(string productCode);
    Task<Product?> GetByCodeAsync(string productCode);
    Task<IReadOnlyList<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);
    Task UpdateAsync(Product product);

    Task<IReadOnlyList<Product>> SearchByNameAsync(string searchText);
}
