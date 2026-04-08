using Codprinter.Products.Application.Dtos.DeleteProductSite;

namespace Codprinter.Products.Application.Interfaces.DeleteProductSite;

public interface IDeleteProductSiteInputPort
{
 Task Handle(DeleteProductSiteRequest request);
}
