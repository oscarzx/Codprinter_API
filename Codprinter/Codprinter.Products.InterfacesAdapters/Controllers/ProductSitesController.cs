using Codprinter.Products.Application.Dtos.CreateProductSite;
using Codprinter.Products.Application.Dtos.DeleteProductSite;
using Codprinter.Products.Application.Dtos.GetAllProductSites;
using Codprinter.Products.Application.Dtos.GetProductSitesByCode;
using Codprinter.Products.Application.Dtos.GetProductSitesByName;
using Codprinter.Products.Application.Dtos.UpdateProductSite;
using Codprinter.Products.Application.Interfaces.CreateProductSite;
using Codprinter.Products.Application.Interfaces.DeleteProductSite;
using Codprinter.Products.Application.Interfaces.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.UpdateProductSite;
using Codprinter.Products.Domain.ValueObjects;
using Codprinter.Products.InterfacesAdapters.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.Products.InterfacesAdapters.Controllers;

public static class ProductSitesController
{
 public static WebApplication UseProductSitesController(this WebApplication app)
 {
 app.MapPost(Endpoints.CreateProductSite, CreateProductSite).WithTags("ProductSites");
 app.MapGet(Endpoints.GetAllProductSites, GetAllProductSites).WithTags("ProductSites");
 app.MapGet(Endpoints.SearchProductSitesByName, SearchProductSitesByName).WithTags("ProductSites");
 app.MapGet(Endpoints.GetProductSitesByCode, GetProductSitesByCode).WithTags("ProductSites");
 app.MapPost(Endpoints.UpdateProductSite, UpdateProductSite).WithTags("ProductSites");
 app.MapPost(Endpoints.DeleteProductSite, DeleteProductSite).WithTags("ProductSites");
 return app;
 }

 private static async Task<IResult> CreateProductSite(
 [FromBody] CreateProductSiteRequest request,
 ICreateProductSiteInputPort inputPort,
 ICreateProductSiteOutputPort outputPort)
 {
 await inputPort.Handle(request);

 var presenter = (CreateProductSitePresenter)outputPort;
 return Results.Ok(presenter.Content ?? new CreateProductSiteResponse());
 }

 private static async Task<IResult> GetAllProductSites(
 IGetAllProductSitesInputPort inputPort,
 IGetAllProductSitesOutputPort outputPort)
 {
 await inputPort.Handle(new GetAllProductSitesRequest());

 var presenter = (GetAllProductSitesPresenter)outputPort;
 return Results.Ok(presenter.Content ?? new GetAllProductSitesResponse());
 }

 private static async Task<IResult> SearchProductSitesByName(
 [FromQuery] string searchText,
 IGetProductSitesByNameInputPort inputPort,
 IGetProductSitesByNameOutputPort outputPort)
 {
 await inputPort.Handle(new GetProductSitesByNameRequest { SearchText = searchText });

 var presenter = (GetProductSitesByNamePresenter)outputPort;
 return Results.Ok(presenter.Content ?? new GetProductSitesByNameResponse());
 }

 private static async Task<IResult> GetProductSitesByCode(
 [FromQuery] string productCode,
 IGetProductSitesByCodeInputPort inputPort,
 IGetProductSitesByCodeOutputPort outputPort)
 {
 await inputPort.Handle(new GetProductSitesByCodeRequest { ProductCode = productCode });

 var presenter = (GetProductSitesByCodePresenter)outputPort;
 return Results.Ok(presenter.Content ?? new GetProductSitesByCodeResponse());
 }

 private static async Task<IResult> UpdateProductSite(
 [FromBody] UpdateProductSiteRequest request,
 IUpdateProductSiteInputPort inputPort,
 IUpdateProductSiteOutputPort outputPort)
 {
 await inputPort.Handle(request);

 var presenter = (UpdateProductSitePresenter)outputPort;
 return Results.Ok(presenter.Content ?? new UpdateProductSiteResponse());
 }

 private static async Task<IResult> DeleteProductSite(
 [FromBody] DeleteProductSiteRequest request,
 IDeleteProductSiteInputPort inputPort,
 IDeleteProductSiteOutputPort outputPort)
 {
 await inputPort.Handle(request);

 var presenter = (DeleteProductSitePresenter)outputPort;
 return Results.Ok(presenter.Content ?? new DeleteProductSiteResponse());
 }
}
