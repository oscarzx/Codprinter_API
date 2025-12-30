using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.Repositories;
using Codprinter.WeighingScales.Application.Mappers;

namespace Codprinter.WeighingScales.Application.UseCases;

internal sealed class GetAllWeighingScalesInteractor(
 IWeighingScaleRepository repository,
 IGetAllWeighingScalesOutputPort outputPort) : IGetAllWeighingScalesInputPort
{
    public async Task Handle(GetAllWeighingScalesRequest request)
    {
        var items = await repository.GetAllAsync();
        var response = items.ToGetAllWeighingScalesResponse();
        outputPort.Handle(response);
    }
}
