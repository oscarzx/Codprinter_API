using Codprinter.Products.Application.Dtos.CreateProduct;

namespace Codprinter.Products.Application.Interfaces.CreateProduct;

public interface ICreateProductInputPort
{
    Task Handle(CreateProductRequest request);
}
