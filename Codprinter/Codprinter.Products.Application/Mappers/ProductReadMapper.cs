using Codprinter.Products.Application.Dtos.GetProduct;
using Codprinter.Products.Application.POCOs;

namespace Codprinter.Products.Application.Mappers;

public static class ProductReadMapper
{
    public static GetProductResponse ToGetProductResponse(this Product product)
    {
        return new GetProductResponse
        {
            Id = product.Id,
            ProductName = product.ProductName,
            ProductCode = product.ProductCode,
            CustomFields = product.CustomFields ?? new()
        };
    }
}
