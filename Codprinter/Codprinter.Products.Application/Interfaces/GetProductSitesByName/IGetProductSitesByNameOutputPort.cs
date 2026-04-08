using Codprinter.Products.Application.Dtos.GetProductSitesByName;

namespace Codprinter.Products.Application.Interfaces.GetProductSitesByName;

public interface IGetProductSitesByNameOutputPort
{
 Task Handle(GetProductSitesByNameResponse response);
}
