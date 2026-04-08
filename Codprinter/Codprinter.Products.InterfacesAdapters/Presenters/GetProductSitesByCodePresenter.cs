using Codprinter.Products.Application.Dtos.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.GetProductSitesByCode;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public sealed class GetProductSitesByCodePresenter : IGetProductSitesByCodeOutputPort
{
 public GetProductSitesByCodeResponse? Content { get; private set; }

 public Task Handle(GetProductSitesByCodeResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
