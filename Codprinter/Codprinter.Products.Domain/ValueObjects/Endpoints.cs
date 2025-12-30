namespace Codprinter.Products.Domain.ValueObjects;

public class Endpoints
{
    public const string CreateProduct = $"/{nameof(CreateProduct)}";
    public const string UpdateProduct = $"/{nameof(UpdateProduct)}";
    public const string GetProductByCode = $"/{nameof(GetProductByCode)}";
    public const string GetProductById = $"/{nameof(GetProductById)}";
    public const string GetProductByName = $"/{nameof(GetProductByName)}";
    public const string GetAllProducts = $"/{nameof(GetAllProducts)}";
    public const string DeleteProduct = $"/{nameof(DeleteProduct)}";
}
