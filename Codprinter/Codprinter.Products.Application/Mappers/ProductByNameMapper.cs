using Codprinter.Products.Application.Dtos.GetProductByName;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductByNameMapper
{
    public static GetProductByNameResponse ToGetProductByNameResponse(this IReadOnlyList<Product> products)
    {
        var response = new GetProductByNameResponse();

        foreach (var p in products)
        {
            response.Items.Add(new ProductByNameItem
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
