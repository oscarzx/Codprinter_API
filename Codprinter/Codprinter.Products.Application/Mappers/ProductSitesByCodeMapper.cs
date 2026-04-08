using Codprinter.Products.Application.Dtos.GetProductSitesByCode;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductSitesByCodeMapper
{
 public static GetProductSitesByCodeResponse ToGetProductSitesByCodeResponse(this IReadOnlyList<ProductSite> items)
 {
 var response = new GetProductSitesByCodeResponse();

 foreach (var ps in items)
 {
 response.Items.Add(new ProductSiteByCodeItem
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
