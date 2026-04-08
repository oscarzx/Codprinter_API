using Codprinter.Products.Application.Dtos.UpdateProductSite;

namespace Codprinter.Products.Application.Interfaces.UpdateProductSite;

public interface IUpdateProductSiteInputPort
{
 Task Handle(UpdateProductSiteRequest request);
}
