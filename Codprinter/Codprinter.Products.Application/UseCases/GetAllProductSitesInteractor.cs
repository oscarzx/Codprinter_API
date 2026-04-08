using Codprinter.Products.Application.Dtos.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal class GetAllProductSitesInteractor(
 IProductSiteRepository repository,
 IGetAllProductSitesOutputPort outputPort) : IGetAllProductSitesInputPort
{
 public async Task Handle(GetAllProductSitesRequest request)
 {
 var items = await repository.GetAllAsync();
 var response = items.ToGetAllProductSitesResponse();
 await outputPort.Handle(response);
 }
}
