using Codprinter.Products.Application.Dtos.UpdateProductSite;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Interfaces.UpdateProductSite;

namespace Codprinter.Products.Application.UseCases;

internal sealed class UpdateProductSiteInteractor(
 IProductSiteRepository repository,
 IProductRepository productRepository,
 IUpdateProductSiteOutputPort outputPort) : IUpdateProductSiteInputPort
{
 public async Task Handle(UpdateProductSiteRequest request)
 {
 var existing = await repository.GetByIdAsync(request.Id);
 if (existing is null)
 {
 throw new ProductSiteNotFoundException(ProductSiteExceptions.ProductSiteNotFound);
 }

 if (!await productRepository.ExistsAsync(request.ProductCode))
 {
 throw new ProductNotFoundException("No existe un producto con el ProductCode indicado.");
 }

 if (await repository.ExistsAsync(request.Site, request.ProductCode) &&
 !(string.Equals(existing.Site, request.Site, StringComparison.Ordinal) &&
 string.Equals(existing.ProductCode, request.ProductCode, StringComparison.Ordinal)))
 {
 throw new ProductSiteAlreadyExistException(ProductSiteExceptions.ProductSiteAlreadyExist);
 }

 existing.Site = request.Site;
 existing.ProductCode = request.ProductCode;
 existing.Price = request.Price;
 existing.Barcode = request.Barcode;
 existing.PriceType = request.PriceType;
 existing.Clearance = request.Clearance;
 existing.LegacyProductCode = request.LegacyProductCode;
 existing.ProductName = request.ProductName;

 await repository.UpdateAsync(existing);
 await repository.SaveChanges();

 await outputPort.Handle(new UpdateProductSiteResponse());
 }
}
