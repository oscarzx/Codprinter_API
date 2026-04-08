using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.POCOs;
using Codprinter.Products.InterfacesAdapters.Gateways.Interfaces;

namespace Codprinter.Products.InterfacesAdapters.Gateways.Repositories;

internal class ProductSiteRepository(ICodprinterProductsCommandsDataContext context) : IProductSiteRepository
{
 public Task AddAsync(ProductSite productSite)
 => context.AddProductSiteAsync(productSite);

 public Task<bool> ExistsAsync(string site, string productCode)
 => context.ExistsProductSiteAsync(site, productCode);

 public async Task<IReadOnlyList<ProductSite>> GetAllAsync()
 => await context.GetAllProductSitesAsync();

 public async Task<IReadOnlyList<ProductSite>> SearchByProductNameAsync(string searchText)
 => await context.SearchProductSitesByProductNameAsync(searchText);

 public async Task<IReadOnlyList<ProductSite>> GetByProductCodeAsync(string productCode)
 => await context.GetProductSitesByProductCodeAsync(productCode);

 public Task<ProductSite?> GetByIdAsync(Guid id)
 => context.GetProductSiteByIdAsync(id);

 public Task UpdateAsync(ProductSite productSite)
 => context.UpdateProductSiteAsync(productSite);

 public Task DeleteAsync(ProductSite productSite)
 => context.DeleteProductSiteAsync(productSite);

 public Task SaveChanges()
 => context.SaveChangesAsync();
}
