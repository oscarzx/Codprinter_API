using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;

namespace Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;

public interface IGetAllWeighingScalesOutputPort
{
    GetAllWeighingScalesResponse? Content { get; }
    void Handle(GetAllWeighingScalesResponse response);
}
