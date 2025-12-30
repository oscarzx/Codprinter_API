namespace Codprinter.Products.Domain;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public Dictionary<string, object?> CustomFields { get; set; }

    public ProductEntity(Guid id, string productCode, string productName, 
        Dictionary<string, object?> customFields = null)
    {
        Id = id;
        ProductCode = productCode;
        ProductName = productName;
        CustomFields = customFields ?? new Dictionary<string, object>();
    }
}
