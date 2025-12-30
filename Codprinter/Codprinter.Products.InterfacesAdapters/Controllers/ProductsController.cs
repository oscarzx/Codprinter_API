using Codprinter.Products.Application.Dtos.CreateProduct;
using Codprinter.Products.Application.Dtos.GetAllProducts;
using Codprinter.Products.Application.Dtos.GetProduct;
using Codprinter.Products.Application.Dtos.GetProductByName;
using Codprinter.Products.Application.Dtos.UpdateProduct;
using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.UpdateProduct;
using Codprinter.Products.Domain.ValueObjects;
using Codprinter.Products.InterfacesAdapters.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.Products.InterfacesAdapters.Controllers;

public static class ProductsController
{
    public static WebApplication UseProductsController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateProduct, CreateProduct).WithTags("Products");
        app.MapGet(Endpoints.GetProductByCode, GetProductByCode).WithTags("Products");
        app.MapGet(Endpoints.GetProductByName, GetProductByName).WithTags("Products");
        app.MapGet(Endpoints.GetAllProducts, GetAllProducts).WithTags("Products");
        app.MapPost(Endpoints.UpdateProduct, UpdateProduct).WithTags("Products");
        return app;
    }

    private static async Task<CreateProductResponse> CreateProduct(
        [FromBody] CreateProductRequest request,
        ICreateProductInputPort inputPort,
        ICreateProductOutputPort outputPort)
    {
        await inputPort.Handle(request);
        return outputPort.Content;
    }

    private static async Task<IResult> GetProductByCode(
        [FromQuery] string productCode,
        IGetProductInputPort inputPort,
        IGetProductOutputPort outputPort)
    {
        await inputPort.Handle(new GetProductRequest { ProductCode = productCode });

        var presenter = (GetProductPresenter)outputPort;
        if (presenter.Content is null)
            return Results.NotFound();

        return Results.Ok(presenter.Content);
    }

    private static async Task<IResult> GetProductByName(
        [FromQuery] string searchText,
        IGetProductByNameInputPort inputPort,
        IGetProductByNameOutputPort outputPort)
    {
        await inputPort.Handle(new GetProductByNameRequest { SearchText = searchText });

        var presenter = (GetProductByNamePresenter)outputPort;
        return Results.Ok(presenter.Content ?? new GetProductByNameResponse());
    }

    private static async Task<IResult> GetAllProducts(
        IGetAllProductsInputPort inputPort,
        IGetAllProductsOutputPort outputPort)
    {
        await inputPort.Handle(new GetAllProductsRequest());

        var presenter = (GetAllProductsPresenter)outputPort;
        return Results.Ok(presenter.Content ?? new GetAllProductsResponse());
    }

    private static async Task<IResult> UpdateProduct(
        [FromBody] UpdateProductRequest request,
        IUpdateProductInputPort inputPort,
        IUpdateProductOutputPort outputPort)
    {
        await inputPort.Handle(request);

        var presenter = (UpdateProductPresenter)outputPort;
        return Results.Ok(presenter.Content ?? new UpdateProductResponse());
    }
}
