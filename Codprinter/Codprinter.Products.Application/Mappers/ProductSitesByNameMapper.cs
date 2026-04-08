using Codprinter.Products.Application.Dtos.GetProductSitesByName;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductSitesByNameMapper
{
 public static GetProductSitesByNameResponse ToGetProductSitesByNameResponse(this IReadOnlyList<ProductSite> items)
 {
 var response = new GetProductSitesByNameResponse();

 foreach (var ps in items)
 {
 response.Items.Add(new ProductSiteByNameItem
 {
 Id = ps.Id,
 Site = ps.Site,
 ProductCode = ps.ProductCode,
 Price = ps.Price,
 Barcode = ps.Barcode,
 PriceType = ps.PriceType,
 Clearance = ps.Clearance,
 LegacyProductCode = ps.LegacyProductCode,
 ProductName = ps.ProductName
 });
 }

 return response;
 }
}
