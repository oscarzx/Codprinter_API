using Codprinter.Products.Application.Dtos.CreateProduct;
using Codprinter.Products.Application.Interfaces.CreateProduct;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

internal class CreateProductPresenter : ICreateProductOutputPort
{
    public CreateProductResponse Content { get; private set; } = default!;

    public Task Handle(CreateProductResponse response)
    {
        Content = response;
        return Task.CompletedTask;
    }
}
