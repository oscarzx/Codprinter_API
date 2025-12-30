using Codprinter.Products.Application.Dtos.GetProductByName;

namespace Codprinter.Products.Application.Interfaces.GetProductByName;

public interface IGetProductByNameOutputPort
{
    GetProductByNameResponse? Content { get; }
    void Handle(GetProductByNameResponse response);
}
