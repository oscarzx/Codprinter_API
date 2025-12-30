using Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale;

namespace Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale
{
    public interface ICreateWeighingScaleOutputPort
    {
        CreateWeighingScaleResponse Content { get; }
        Task Handle(CreateWeighingScaleResponse response);
    }
}
