using Codprinter.Products.Application.Dtos.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.GetProductSitesByName;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public sealed class GetProductSitesByNamePresenter : IGetProductSitesByNameOutputPort
{
 public GetProductSitesByNameResponse? Content { get; private set; }

 public Task Handle(GetProductSitesByNameResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
