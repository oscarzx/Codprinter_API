using Codprinter.Products.Application.Dtos.CreateProductSite;

namespace Codprinter.Products.Application.Interfaces.CreateProductSite;

public interface ICreateProductSiteInputPort
{
 Task Handle(CreateProductSiteRequest request);
}
