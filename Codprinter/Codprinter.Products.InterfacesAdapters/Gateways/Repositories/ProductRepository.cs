using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.POCOs;
using Codprinter.Products.InterfacesAdapters.Gateways.Interfaces;

namespace Codprinter.Products.InterfacesAdapters.Gateways.Repositories
{
    internal class ProductRepository(
        ICodprinterProductsCommandsDataContext context) : IProductRepository
    {
        public async Task AddAsync(Product product)
            => await context.AddProductAsync(product);

        public async Task<bool> ExistsAsync(string productCode)
            => await context.ExistsProductAsync(productCode);

        public Task<Product?> GetByCodeAsync(string productCode)
            => context.GetProductByCodeAsync(productCode);

        public async Task<IReadOnlyList<Product>> GetAllAsync()
            => await context.GetAllProductsAsync();

        public Task<Product?> GetByIdAsync(Guid id)
            => context.GetProductByIdAsync(id);

        public Task UpdateAsync(Product product)
            => context.UpdateProductAsync(product);

        public async Task<IReadOnlyList<Product>> SearchByNameAsync(string searchText)
            => await context.SearchProductsByNameAsync(searchText);

        public async Task SaveChanges()
            => await context.SaveChangesAsync();
    }
}
