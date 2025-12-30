namespace Codprinter.Products.Application.POCOs;

public class Product
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public Dictionary<string, object?> CustomFields { get; set; }
}
