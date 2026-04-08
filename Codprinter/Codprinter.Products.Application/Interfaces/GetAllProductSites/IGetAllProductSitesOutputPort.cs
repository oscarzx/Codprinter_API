using Codprinter.Products.Application.Dtos.GetAllProductSites;

namespace Codprinter.Products.Application.Interfaces.GetAllProductSites;

public interface IGetAllProductSitesOutputPort
{
 Task Handle(GetAllProductSitesResponse response);
}
