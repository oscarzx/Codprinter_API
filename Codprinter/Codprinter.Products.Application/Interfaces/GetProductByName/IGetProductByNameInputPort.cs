using Codprinter.Products.Application.Dtos.GetProductByName;

namespace Codprinter.Products.Application.Interfaces.GetProductByName;

public interface IGetProductByNameInputPort
{
    Task Handle(GetProductByNameRequest request);
}
