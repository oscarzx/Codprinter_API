namespace Codprinter.Products.Application.Dtos.GetProductByName;

public sealed class GetProductByNameResponse
{
    public List<ProductByNameItem> Items { get; set; } = new();
}

public sealed class ProductByNameItem
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public Dictionary<string, object?> CustomFields { get; set; } = new();
}
