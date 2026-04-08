namespace Codprinter.Products.Application.Dtos.CreateProductSite;

public class CreateProductSiteRequest
{
 public string Site { get; set; }
 public string ProductCode { get; set; }
 public decimal Price { get; set; }

 public string? Barcode { get; set; }
 public string? PriceType { get; set; }
 public string? Clearance { get; set; }
 public string? LegacyProductCode { get; set; }
 public string? ProductName { get; set; }
}
