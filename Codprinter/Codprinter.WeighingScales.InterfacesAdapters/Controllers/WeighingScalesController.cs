using Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;
using Codprinter.WeighingScales.Domain.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.WeighingScales.InterfacesAdapters.Controllers
{
    public static class WeighingScalesController
    {
        public static WebApplication UseWeighingScalesController(this WebApplication app)
        {
            app.MapPost(Endpoints.CreateWeighingScale, CreateWeighingScale).WithTags("WeighingScales");
            app.MapGet(Endpoints.GetAllWeighingScales, GetAllWeighingScales).WithTags("WeighingScales");
            app.MapPost(Endpoints.UpdateWeighingScale, UpdateWeighingScale).WithTags("WeighingScales");

            return app;
        }

        public static async Task<CreateWeighingScaleResponse> CreateWeighingScale(
            [FromBody] CreateWeighingScaleRequest request,
            ICreateWeighingScaleInputPort inputPort,
            ICreateWeighingScaleOutputPort outputPort)
        {
            await inputPort.Handle(request);
            return outputPort.Content;
        }

        public static async Task<GetAllWeighingScalesResponse> GetAllWeighingScales(
            IGetAllWeighingScalesInputPort inputPort,
            IGetAllWeighingScalesOutputPort outputPort)
        {
            await inputPort.Handle(new GetAllWeighingScalesRequest());
            return outputPort.Content!;
        }

        public static async Task<UpdateWeighingScaleResponse> UpdateWeighingScale(
            [FromBody] UpdateWeighingScaleRequest request,
            IUpdateWeighingScaleInputPort inputPort,
            IUpdateWeighingScaleOutputPort outputPort)
        {
            await inputPort.Handle(request);
            return outputPort.Content!;
        }
    }
}
