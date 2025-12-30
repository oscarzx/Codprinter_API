using Codprinter.Products.Application.Dtos.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetAllProducts;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

internal sealed class GetAllProductsPresenter : IGetAllProductsOutputPort
{
    public GetAllProductsResponse? Content { get; private set; }

    public void Handle(GetAllProductsResponse response)
    {
        Content = response;
    }
}
