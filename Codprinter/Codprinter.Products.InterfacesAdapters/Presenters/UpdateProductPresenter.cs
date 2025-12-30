using Codprinter.Products.Application.Dtos.UpdateProduct;
using Codprinter.Products.Application.Interfaces.UpdateProduct;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

internal sealed class UpdateProductPresenter : IUpdateProductOutputPort
{
    public UpdateProductResponse? Content { get; private set; }

    public void Handle(UpdateProductResponse response)
    {
        Content = response;
    }
}
