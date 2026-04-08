using Codprinter.Products.Application.POCOs;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Products.Application.Interfaces.Repositories;

public interface IProductSiteRepository : IUnitOfWork
{
 Task AddAsync(ProductSite productSite);
 Task<bool> ExistsAsync(string site, string productCode);
 Task<IReadOnlyList<ProductSite>> GetAllAsync();
 Task<IReadOnlyList<ProductSite>> SearchByProductNameAsync(string searchText);
 Task<IReadOnlyList<ProductSite>> GetByProductCodeAsync(string productCode);

 Task<ProductSite?> GetByIdAsync(Guid id);
 Task UpdateAsync(ProductSite productSite);
 Task DeleteAsync(ProductSite productSite);
}
