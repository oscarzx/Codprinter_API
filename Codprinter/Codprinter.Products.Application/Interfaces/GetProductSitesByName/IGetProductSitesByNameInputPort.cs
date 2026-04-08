using Codprinter.Products.Application.Dtos.GetProductSitesByName;

namespace Codprinter.Products.Application.Interfaces.GetProductSitesByName;

public interface IGetProductSitesByNameInputPort
{
 Task Handle(GetProductSitesByNameRequest request);
}
