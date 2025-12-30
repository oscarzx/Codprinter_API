using Codprinter.Products.Application.Dtos.GetProduct;

namespace Codprinter.Products.Application.Interfaces.GetProduct;

public interface IGetProductInputPort
{
    Task Handle(GetProductRequest request);
}
