using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.InterfacesAdapters.Gateways.Interfaces;

public interface ICodprinterProductsCommandsDataContext
{
    Task AddProductAsync(Product product);
    Task<bool> ExistsProductAsync(string productCode);
    Task<Product?> GetProductByCodeAsync(string productCode);
    Task<List<Product>> GetAllProductsAsync();

    Task<Product?> GetProductByIdAsync(Guid id);
    Task<List<Product>> SearchProductsByNameAsync(string searchText);
    Task UpdateProductAsync(Product product);

    Task SaveChangesAsync();
}
