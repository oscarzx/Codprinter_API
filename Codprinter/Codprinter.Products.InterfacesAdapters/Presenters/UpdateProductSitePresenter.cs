using Codprinter.Products.Application.Dtos.UpdateProductSite;
using Codprinter.Products.Application.Interfaces.UpdateProductSite;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public sealed class UpdateProductSitePresenter : IUpdateProductSiteOutputPort
{
 public UpdateProductSiteResponse? Content { get; private set; }

 public Task Handle(UpdateProductSiteResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
