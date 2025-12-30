using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;

namespace Codprinter.WeighingScales.InterfacesAdapters.Presenters.Presenters;

public sealed class UpdateWeighingScalePresenter : IUpdateWeighingScaleOutputPort
{
    public UpdateWeighingScaleResponse? Content { get; private set; }

    public void Handle(UpdateWeighingScaleResponse response)
    {
        Content = response;
    }
}
