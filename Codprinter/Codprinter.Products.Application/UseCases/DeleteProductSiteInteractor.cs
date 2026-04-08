using Codprinter.Products.Application.Dtos.DeleteProductSite;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.DeleteProductSite;
using Codprinter.Products.Application.Interfaces.Repositories;

namespace Codprinter.Products.Application.UseCases;

internal sealed class DeleteProductSiteInteractor(
 IProductSiteRepository repository,
 IDeleteProductSiteOutputPort outputPort) : IDeleteProductSiteInputPort
{
 public async Task Handle(DeleteProductSiteRequest request)
 {
 var existing = await repository.GetByIdAsync(request.Id);
 if (existing is null)
 {
 throw new ProductSiteNotFoundException(ProductSiteExceptions.ProductSiteNotFound);
 }

 await repository.DeleteAsync(existing);
 await repository.SaveChanges();

 await outputPort.Handle(new DeleteProductSiteResponse());
 }
}
