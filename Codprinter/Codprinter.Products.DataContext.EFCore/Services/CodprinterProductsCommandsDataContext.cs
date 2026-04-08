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

        public Task AddProductSiteAsync(ProductSite productSite)
            => AddAsync(productSite).AsTask();

        public Task<bool> ExistsProductSiteAsync(string site, string productCode)
            => ProductSites.AnyAsync(ps => ps.Site == site && ps.ProductCode == productCode);

        public async Task<List<ProductSite>> GetAllProductSitesAsync()
            => await ProductSites
                .AsNoTracking()
                .OrderBy(ps => ps.Site)
                .ThenBy(ps => ps.ProductCode)
                .ToListAsync();

        public async Task<List<ProductSite>> SearchProductSitesByProductNameAsync(string searchText)
        {
            var term = (searchText ?? string.Empty).Trim();
            if (term.Length == 0)
                return new List<ProductSite>();

            return await ProductSites
                .AsNoTracking()
                .Where(ps => ps.ProductName != null && EF.Functions.ILike(ps.ProductName, $"%{term}%"))
                .OrderBy(ps => ps.Site)
                .ThenBy(ps => ps.ProductName)
                .ToListAsync();
        }

        public async Task<List<ProductSite>> GetProductSitesByProductCodeAsync(string productCode)
        {
            var code = (productCode ?? string.Empty).Trim();
            if (code.Length == 0)
                return new List<ProductSite>();

            return await ProductSites
                .AsNoTracking()
                .Where(ps => ps.ProductCode == code)
                .OrderBy(ps => ps.Site)
                .ToListAsync();
        }

        public Task<ProductSite?> GetProductSiteByIdAsync(Guid id)
            => ProductSites.FirstOrDefaultAsync(ps => ps.Id == id);

        public Task UpdateProductSiteAsync(ProductSite productSite)
        {
            ProductSites.Update(productSite);
            return Task.CompletedTask;
        }

        public Task DeleteProductSiteAsync(ProductSite productSite)
        {
            ProductSites.Remove(productSite);
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
