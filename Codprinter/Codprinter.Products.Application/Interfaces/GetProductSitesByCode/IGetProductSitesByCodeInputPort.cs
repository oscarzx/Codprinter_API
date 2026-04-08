using Codprinter.Products.Application.Dtos.GetProductSitesByCode;

namespace Codprinter.Products.Application.Interfaces.GetProductSitesByCode;

public interface IGetProductSitesByCodeInputPort
{
 Task Handle(GetProductSitesByCodeRequest request);
}
