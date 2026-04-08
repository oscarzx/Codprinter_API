using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.CreateProductSite;
using Codprinter.Products.Application.Interfaces.DeleteProductSite;
using Codprinter.Products.Application.Interfaces.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.UpdateProductSite;
using Codprinter.Products.Application.Interfaces.UpdateProduct;
using Codprinter.Products.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductInputPort, CreateProductInteractor>();
            services.AddScoped<IGetProductInputPort, GetProductInteractor>();
            services.AddScoped<IGetAllProductsInputPort, GetAllProductsInteractor>();
            services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();
            services.AddScoped<IGetProductByNameInputPort, GetProductByNameInteractor>();
            services.AddScoped<ICreateProductSiteInputPort, CreateProductSiteInteractor>();
            services.AddScoped<IGetAllProductSitesInputPort, GetAllProductSitesInteractor>();
            services.AddScoped<IGetProductSitesByNameInputPort, GetProductSitesByNameInteractor>();
            services.AddScoped<IGetProductSitesByCodeInputPort, GetProductSitesByCodeInteractor>();
            services.AddScoped<IUpdateProductSiteInputPort, UpdateProductSiteInteractor>();
            services.AddScoped<IDeleteProductSiteInputPort, DeleteProductSiteInteractor>();
            return services;
        }
    }
}
