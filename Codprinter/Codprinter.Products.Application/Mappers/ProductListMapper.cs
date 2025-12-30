using Codprinter.Products.Application.Dtos.GetAllProducts;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductListMapper
{
    public static GetAllProductsResponse ToGetAllProductsResponse(this IReadOnlyList<Product> products)
    {
        var response = new GetAllProductsResponse();

        foreach (var p in products)
        {
            response.Items.Add(new ProductListItem
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductCode = p.ProductCode,
                CustomFields = p.CustomFields ?? new()
            });
        }

        return response;
    }
}
