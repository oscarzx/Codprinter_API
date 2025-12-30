namespace Codprinter.Products.Application.Dtos.GetProduct;

public sealed class GetProductResponse
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public Dictionary<string, object?> CustomFields { get; set; } = new();
}
