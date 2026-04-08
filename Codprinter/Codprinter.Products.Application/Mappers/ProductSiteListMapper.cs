using Codprinter.Products.Application.Dtos.GetAllProductSites;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductSiteListMapper
{
 public static GetAllProductSitesResponse ToGetAllProductSitesResponse(this IReadOnlyList<ProductSite> items)
 {
 var response = new GetAllProductSitesResponse();

 foreach (var ps in items)
 {
 response.Items.Add(new ProductSiteListItem
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
