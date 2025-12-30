using Codprinter.Products.Application.Dtos.GetProductByName;
using Codprinter.Products.Application.Interfaces.GetProductByName;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

internal sealed class GetProductByNamePresenter : IGetProductByNameOutputPort
{
    public GetProductByNameResponse? Content { get; private set; }

    public void Handle(GetProductByNameResponse response)
    {
        Content = response;
    }
}
