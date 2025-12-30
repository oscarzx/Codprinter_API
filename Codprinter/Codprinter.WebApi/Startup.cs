using Codprinter.Labels.IoC;
using Codprinter.Printers.IoC;
using Codprinter.Products.IoC;
using Codprinter.Printing.IoC;
using Codprinter.Shared.Infrastructure.Options;
using Codprinter.WeighingScales.IoC;

namespace Codprinter.WebApi;

public static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddHttpContextAccessor();

        //Services
        builder.Services
            .AddLabelServices(
                builder.Configuration,
                options => 
                builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(options))
            .AddPrinterServices(
                builder.Configuration,
                options =>
                builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(options))
            .AddProductServices(
                builder.Configuration,
                options =>
                builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(options))
            .AddWeighingScaleServices(
                builder.Configuration,
                options => 
                builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(options))
            .AddPrintingServices();


        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        return builder.Build();
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<Middlewares.ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseCors();

        //Autenticación
        //Autorización

        app.MapCodprinterLabelsEndpoints();
        app.MapCodprinterPrintersEndpoints();
        app.MapCodprinterProductsEndpoints();
        app.MapCodprinterWeighingScalesEndpoints();
        app.MapCodprinterPrintingEndpoints();

        return app;
    }
}
