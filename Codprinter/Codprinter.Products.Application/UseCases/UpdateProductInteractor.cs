using Codprinter.Products.Application.Dtos.UpdateProduct;
using Codprinter.Products.Application.Exceptions;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Interfaces.UpdateProduct;

namespace Codprinter.Products.Application.UseCases;

internal sealed class UpdateProductInteractor(
 IProductRepository repository,
 IUpdateProductOutputPort outputPort) : IUpdateProductInputPort
{
    public async Task Handle(UpdateProductRequest request)
    {
        if (request.Id == Guid.Empty)
            throw new ArgumentException("Id es requerido.");

        if (string.IsNullOrWhiteSpace(request.ProductCode))
            throw new ArgumentException("ProductCode es requerido.");

        if (string.IsNullOrWhiteSpace(request.ProductName))
            throw new ArgumentException("ProductName es requerido.");

        var current = await repository.GetByIdAsync(request.Id);
        if (current is null)
            throw new ProductNotFoundException($"No se encontró el producto con id '{request.Id}'.");

        var normalizedCode = request.ProductCode.Trim();
        if (!string.Equals(current.ProductCode, normalizedCode, StringComparison.OrdinalIgnoreCase))
        {
            if (await repository.ExistsAsync(normalizedCode))
                throw new ProductCodeConflictException("Ya existe un producto con ese ProductCode.");
        }

        current.ProductName = request.ProductName.Trim();
        current.ProductCode = normalizedCode;
        current.CustomFields = request.CustomFields ?? new();

        await repository.UpdateAsync(current);
        await repository.SaveChanges();

        outputPort.Handle(new UpdateProductResponse());
    }
}
