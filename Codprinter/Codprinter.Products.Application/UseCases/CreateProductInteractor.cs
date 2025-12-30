using Codprinter.Products.Application.Dtos.CreateProduct;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;
using Codprinter.Products.Domain;

namespace Codprinter.Products.Application.UseCases;

internal class CreateProductInteractor(
    IProductRepository repository,
    ICreateProductOutputPort outputPort) : ICreateProductInputPort
{
    public async Task Handle(CreateProductRequest request)
    {
        if (await repository.ExistsAsync(request.ProductCode))
        {
            throw new ProductAlreadyExistException("Ya existe un producto con el mismo código.");
        }

        var product = new ProductEntity(
            Guid.NewGuid(),
            request.ProductCode,
            request.ProductName,
            request.CustomFields?.ToDictionary(kvp => kvp.Key, kvp => (object?)kvp.Value)
        );

        await repository.AddAsync(product.ToNewProduct());
        await repository.SaveChanges();

        var response = new CreateProductResponse
        {
            Message = "Producto creado exitosamente."
        };

        await outputPort.Handle(response);
    }
}
