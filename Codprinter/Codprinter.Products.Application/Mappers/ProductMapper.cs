using Codprinter.Products.Application.POCOs;
using Codprinter.Products.Domain;

namespace Codprinter.Products.Application.Mappers;

public static class ProductMapper
{
    public static Product ToNewProduct(this ProductEntity entity)
        => new Product
        {
            Id = Guid.NewGuid(),
            ProductName = entity.ProductName,
            ProductCode =  entity.ProductCode,
            CustomFields = entity.CustomFields,
        };
}
