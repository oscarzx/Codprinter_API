using Codprinter.Products.Application.POCOs;
using Codprinter.Products.DataContext.EFCore.DataContexts;
using Codprinter.Products.InterfacesAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Codprinter.Products.DataContext.EFCore.Services
{
    internal sealed class CodprinterProductsCommandsDataContext(IOptions<DBOptions> options) :
        CodprinterProductsContext(options),
        ICodprinterProductsCommandsDataContext
    {
        public async Task AddProductAsync(Product product)
            => await AddAsync(product);

        public async Task<bool> ExistsProductAsync(string productCode)
            => await Products.AnyAsync(p => p.ProductCode == productCode);

        public async Task<Product?> GetProductByCodeAsync(string productCode)
            => await Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductCode == productCode);

        public async Task<List<Product>> GetAllProductsAsync()
            => await Products
                .AsNoTracking()
                .OrderBy(p => p.ProductName)
                .ToListAsync();

        public Task<Product?> GetProductByIdAsync(Guid id)
            => Products.FirstOrDefaultAsync(p => p.Id == id);

        public Task UpdateProductAsync(Product product)
        {
            Products.Update(product);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public async Task<List<Product>> SearchProductsByNameAsync(string searchText)
        {
            var term = (searchText ?? string.Empty).Trim();
            if (term.Length == 0)
                return new List<Product>();

            // PostgreSQL: ILIKE (case-insensitive)
            return await Products
                .AsNoTracking()
                .Where(p => EF.Functions.ILike(p.ProductName, $"%{term}%"))
                .OrderBy(p => p.ProductName)
                .ToListAsync();
        }
    }
}
