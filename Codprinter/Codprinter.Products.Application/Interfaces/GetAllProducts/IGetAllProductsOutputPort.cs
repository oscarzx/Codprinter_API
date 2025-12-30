using Codprinter.Products.Application.Dtos.GetAllProducts;

namespace Codprinter.Products.Application.Interfaces.GetAllProducts;

public interface IGetAllProductsOutputPort
{
    GetAllProductsResponse? Content { get; }
    void Handle(GetAllProductsResponse response);
}
