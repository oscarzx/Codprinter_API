namespace Codprinter.Products.Application.Dtos.CreateProduct;

public class CreateProductRequest
{
    public string ProductName { get; set; } = default!;
    public string ProductCode { get; set; } = default!;
    public Dictionary<string, string>? CustomFields { get; set; }
}
