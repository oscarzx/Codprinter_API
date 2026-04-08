using Codprinter.Products.Application.Dtos.GetProductSitesByCode;

namespace Codprinter.Products.Application.Interfaces.GetProductSitesByCode;

public interface IGetProductSitesByCodeOutputPort
{
 Task Handle(GetProductSitesByCodeResponse response);
}
