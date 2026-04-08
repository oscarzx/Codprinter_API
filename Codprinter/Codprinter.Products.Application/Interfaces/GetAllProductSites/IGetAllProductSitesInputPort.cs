using Codprinter.Products.Application.Dtos.GetAllProductSites;

namespace Codprinter.Products.Application.Interfaces.GetAllProductSites;

public interface IGetAllProductSitesInputPort
{
 Task Handle(GetAllProductSitesRequest request);
}
