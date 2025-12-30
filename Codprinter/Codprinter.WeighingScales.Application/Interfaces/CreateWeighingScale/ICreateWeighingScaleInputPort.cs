using Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale;

namespace Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale
{
    public interface ICreateWeighingScaleInputPort
    {
        Task Handle(CreateWeighingScaleRequest request);
    }
}
