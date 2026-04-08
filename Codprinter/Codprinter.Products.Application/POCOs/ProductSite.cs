namespace Codprinter.Products.Application.POCOs;

public class ProductSite
{
 public Guid Id { get; set; }
 public string Site { get; set; }
 public string? Barcode { get; set; }
 public string? PriceType { get; set; }
 public string? Clearance { get; set; }
 public string ProductCode { get; set; }
 public string? LegacyProductCode { get; set; }
 public string? ProductName { get; set; }
 public decimal Price { get; set; }
}
