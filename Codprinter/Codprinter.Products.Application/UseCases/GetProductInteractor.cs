using Codprinter.Products.Application.Dtos.GetProduct;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal sealed class GetProductInteractor(
 IProductRepository repository,
 IGetProductOutputPort outputPort) : IGetProductInputPort
{
    public async Task Handle(GetProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ProductCode))
            throw new ArgumentException("ProductCode es requerido.");

        var product = await repository.GetByCodeAsync(request.ProductCode.Trim());
        if (product is null)
            throw new ProductNotFoundException($"No se encontró el producto '{request.ProductCode}'.");

        outputPort.Handle(product.ToGetProductResponse());
    }
}
