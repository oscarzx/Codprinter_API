using Codprinter.Products.Application.Dtos.DeleteProductSite;
using Codprinter.Products.Application.Interfaces.DeleteProductSite;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public sealed class DeleteProductSitePresenter : IDeleteProductSiteOutputPort
{
 public DeleteProductSiteResponse? Content { get; private set; }

 public Task Handle(DeleteProductSiteResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
