using Codprinter.Products.Application.Dtos.GetProduct;

namespace Codprinter.Products.Application.Interfaces.GetProduct;

public interface IGetProductOutputPort
{
    GetProductResponse? Content { get; }
    void Handle(GetProductResponse response);
}
