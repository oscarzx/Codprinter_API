using Codprinter.Products.Application.Dtos.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Mappers;

namespace Codprinter.Products.Application.UseCases;

internal sealed class GetAllProductsInteractor(
 IProductRepository repository,
 IGetAllProductsOutputPort outputPort) : IGetAllProductsInputPort
{
    public async Task Handle(GetAllProductsRequest request)
    {
        var products = await repository.GetAllAsync();
        var response = products.ToGetAllProductsResponse();
        outputPort.Handle(response);
    }
}
