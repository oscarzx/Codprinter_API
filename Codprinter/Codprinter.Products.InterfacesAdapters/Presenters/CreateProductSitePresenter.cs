using Codprinter.Products.Application.Dtos.CreateProductSite;
using Codprinter.Products.Application.Interfaces.CreateProductSite;

namespace Codprinter.Products.InterfacesAdapters.Presenters;

public class CreateProductSitePresenter : ICreateProductSiteOutputPort
{
 public CreateProductSiteResponse? Content { get; private set; }

 public Task Handle(CreateProductSiteResponse response)
 {
 Content = response;
 return Task.CompletedTask;
 }
}
