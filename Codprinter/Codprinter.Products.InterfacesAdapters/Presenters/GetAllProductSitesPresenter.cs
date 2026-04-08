using Codprinter.Products.Application.Dtos.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.GetAllProductSites;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public sealed class GetAllProductSitesPresenter : IGetAllProductSitesOutputPort
{
 public GetAllProductSitesResponse? Content { get; private set; }

 public Task Handle(GetAllProductSitesResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
