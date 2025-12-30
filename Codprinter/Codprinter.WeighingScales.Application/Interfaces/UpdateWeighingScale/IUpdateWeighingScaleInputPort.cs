using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;

namespace Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;

public interface IUpdateWeighingScaleInputPort
{
    Task Handle(UpdateWeighingScaleRequest request);
}
