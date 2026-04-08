namespace Codprinter.Products.Application.Dtos.UpdateProductSite;

public sealed class UpdateProductSiteRequest
{
 public Guid Id { get; set; }

 public string Site { get; set; } = string.Empty;
 public string ProductCode { get; set; } = string.Empty;
 public decimal Price { get; set; }

 public string? Barcode { get; set; }
 public string? PriceType { get; set; }
 public string? Clearance { get; set; }
 public string? LegacyProductCode { get; set; }
 public string? ProductName { get; set; }
}
