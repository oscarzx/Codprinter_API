using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;

namespace Codprinter.WeighingScales.InterfacesAdapters.Presenters;

public sealed class GetAllWeighingScalesPresenter : IGetAllWeighingScalesOutputPort
{
    public GetAllWeighingScalesResponse Content { get; private set; } = new();

    public void Handle(GetAllWeighingScalesResponse response)
    {
        Content = response;
    }
}
