using Codprinter.Products.Application.POCOs;
using Codprinter.Products.Domain;

namespace Codprinter.Products.Application.Mappers;

public static class ProductSiteMapper
{
 public static ProductSite ToNewProductSite(this ProductSiteEntity entity)
 {
 return new ProductSite
 {
 Id = entity.Id,
 Site = entity.Site,
 Barcode = entity.Barcode,
 PriceType = entity.PriceType,
 Clearance = entity.Clearance,
 ProductCode = entity.ProductCode,
 LegacyProductCode = entity.LegacyProductCode,
 ProductName = entity.ProductName,
 Price = entity.Price
 };
 }
}
