using Codprinter.Products.Application.Dtos.CreateProductSite;

namespace Codprinter.Products.Application.Interfaces.CreateProductSite;

public interface ICreateProductSiteOutputPort
{
 Task Handle(CreateProductSiteResponse response);
}
