using Codprinter.Products.Application.Dtos.CreateProductSite;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.CreateProductSite;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;
using Codprinter.Products.Domain;

namespace Codprinter.Products.Application.UseCases;

internal class CreateProductSiteInteractor(
 IProductSiteRepository repository,
 IProductRepository productRepository,
 ICreateProductSiteOutputPort outputPort) : ICreateProductSiteInputPort
{
    public async Task Handle(CreateProductSiteRequest request)
    {
        if (!await productRepository.ExistsAsync(request.ProductCode))
        {
            throw new ProductNotFoundException("No existe un producto con el ProductCode indicado.");
        }

        if (await repository.ExistsAsync(request.Site, request.ProductCode))
        {
            throw new ProductSiteAlreadyExistException(ProductSiteExceptions.ProductSiteAlreadyExist);
        }

        var entity = new ProductSiteEntity(
        id: Guid.NewGuid(),
        site: request.Site,
        productCode: request.ProductCode,
        price: request.Price,
        barcode: request.Barcode,
        priceType: request.PriceType,
        clearance: request.Clearance,
        legacyProductCode: request.LegacyProductCode,
        productName: request.ProductName);

        await repository.AddAsync(entity.ToNewProductSite());
        await repository.SaveChanges();

        await outputPort.Handle(new CreateProductSiteResponse
        {
            Message = "Sede agregada exitosamente."
        });
    }
}
