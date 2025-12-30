using Codprinter.Products.Application.Dtos.GetAllProducts;

namespace Codprinter.Products.Application.Interfaces.GetAllProducts;

public interface IGetAllProductsInputPort
{
    Task Handle(GetAllProductsRequest request);
}
