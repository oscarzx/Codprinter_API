using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;

namespace Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;

public interface IGetAllWeighingScalesInputPort
{
    Task Handle(GetAllWeighingScalesRequest request);
}
