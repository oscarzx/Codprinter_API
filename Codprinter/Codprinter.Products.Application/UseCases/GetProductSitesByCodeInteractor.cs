using Codprinter.Products.Application.Dtos.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal sealed class GetProductSitesByCodeInteractor(
 IProductSiteRepository repository,
 IGetProductSitesByCodeOutputPort outputPort) : IGetProductSitesByCodeInputPort
{
 public async Task Handle(GetProductSitesByCodeRequest request)
 {
 var items = await repository.GetByProductCodeAsync(request.ProductCode);
 await outputPort.Handle(items.ToGetProductSitesByCodeResponse());
 }
}
