using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;

namespace Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;

public interface IUpdateWeighingScaleOutputPort
{
    UpdateWeighingScaleResponse? Content { get; }
    void Handle(UpdateWeighingScaleResponse response);
}
