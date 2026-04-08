using Codprinter.Products.Application.Dtos.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal sealed class GetProductSitesByNameInteractor(
 IProductSiteRepository repository,
 IGetProductSitesByNameOutputPort outputPort) : IGetProductSitesByNameInputPort
{
 public async Task Handle(GetProductSitesByNameRequest request)
 {
 var items = await repository.SearchByProductNameAsync(request.SearchText);
 await outputPort.Handle(items.ToGetProductSitesByNameResponse());
 }
}
