using Codprinter.Products.Application.Dtos.UpdateProductSite;

namespace Codprinter.Products.Application.Interfaces.UpdateProductSite;

public interface IUpdateProductSiteOutputPort
{
 Task Handle(UpdateProductSiteResponse response);
}
