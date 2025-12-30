using Codprinter.Products.Application.Dtos.UpdateProduct;

namespace Codprinter.Products.Application.Interfaces.UpdateProduct;

public interface IUpdateProductOutputPort
{
    UpdateProductResponse? Content { get; }
    void Handle(UpdateProductResponse response);
}
