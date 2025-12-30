using Codprinter.Products.Application.Dtos.UpdateProduct;

namespace Codprinter.Products.Application.Interfaces.UpdateProduct;

public interface IUpdateProductInputPort
{
    Task Handle(UpdateProductRequest request);
}
