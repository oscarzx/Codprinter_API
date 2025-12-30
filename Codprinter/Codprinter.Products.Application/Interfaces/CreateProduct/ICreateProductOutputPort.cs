using Codprinter.Products.Application.Dtos.CreateProduct;

namespace Codprinter.Products.Application.Interfaces.CreateProduct;

public interface ICreateProductOutputPort
{
    CreateProductResponse Content { get; }
    Task Handle(CreateProductResponse response);
}
