namespace Codprinter.Products.Domain.ValueObjects;

public static class Endpoints
{
    public const string CreateProduct = $"/{nameof(CreateProduct)}";
    public const string GetProductByCode = $"/{nameof(GetProductByCode)}";
    public const string GetAllProducts = $"/{nameof(GetAllProducts)}";
    public const string UpdateProduct = $"/{nameof(UpdateProduct)}";
    public const string GetProductByName = $"/{nameof(GetProductByName)}";

    public const string CreateProductSite = $"/{nameof(CreateProductSite)}";
    public const string GetAllProductSites = $"/{nameof(GetAllProductSites)}";
    public const string SearchProductSitesByName = $"/{nameof(SearchProductSitesByName)}";
    public const string GetProductSitesByCode = $"/{nameof(GetProductSitesByCode)}";
    public const string UpdateProductSite = $"/{nameof(UpdateProductSite)}";
    public const string DeleteProductSite = $"/{nameof(DeleteProductSite)}";
}
