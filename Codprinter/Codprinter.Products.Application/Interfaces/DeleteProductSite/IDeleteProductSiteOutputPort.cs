using Codprinter.Products.Application.Dtos.DeleteProductSite;

namespace Codprinter.Products.Application.Interfaces.DeleteProductSite;

public interface IDeleteProductSiteOutputPort
{
 Task Handle(DeleteProductSiteResponse response);
}
