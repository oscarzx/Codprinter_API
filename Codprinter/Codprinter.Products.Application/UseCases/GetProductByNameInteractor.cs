using Codprinter.Products.Application.Dtos.GetProductByName;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal sealed class GetProductByNameInteractor(
 IProductRepository repository,
 IGetProductByNameOutputPort outputPort) : IGetProductByNameInputPort
{
    public async Task Handle(GetProductByNameRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SearchText))
            throw new ArgumentException("SearchText es requerido.");

        var products = await repository.SearchByNameAsync(request.SearchText);
        var response = products.ToGetProductByNameResponse();
        outputPort.Handle(response);
    }
}
