using Codprinter.Products.Application.Dtos.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProduct;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

internal sealed class GetProductPresenter : IGetProductOutputPort
{
    public GetProductResponse? Content { get; private set; }

    public void Handle(GetProductResponse response)
    {
        Content = response;
    }
}
