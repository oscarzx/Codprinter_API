using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.CreateProductSite;
using Codprinter.Products.Application.Interfaces.DeleteProductSite;
using Codprinter.Products.Application.Interfaces.GetAllProductSites;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.GetProductSitesByCode;
using Codprinter.Products.Application.Interfaces.GetProductSitesByName;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Interfaces.UpdateProductSite;
using Codprinter.Products.Application.Interfaces.UpdateProduct;
using Codprinter.Products.InterfacesAdapters.Gateways.Repositories;
using Codprinter.Products.InterfacesAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.InterfacesAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductPresenters(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSiteRepository, ProductSiteRepository>();

            services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();
            services.AddScoped<IGetProductOutputPort, GetProductPresenter>();
            services.AddScoped<IGetAllProductsOutputPort, GetAllProductsPresenter>();
            services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();
            services.AddScoped<IGetProductByNameOutputPort, GetProductByNamePresenter>();
            services.AddScoped<ICreateProductSiteOutputPort, CreateProductSitePresenter>();

            services.AddScoped<IGetAllProductSitesOutputPort, GetAllProductSitesPresenter>();
            services.AddScoped<IGetProductSitesByNameOutputPort, GetProductSitesByNamePresenter>();
            services.AddScoped<IGetProductSitesByCodeOutputPort, GetProductSitesByCodePresenter>();
            services.AddScoped<IUpdateProductSiteOutputPort, UpdateProductSitePresenter>();
            services.AddScoped<IDeleteProductSiteOutputPort, DeleteProductSitePresenter>();

            return services;
        }
    }
}
