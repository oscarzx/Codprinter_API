using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.POCOs;
using Codprinter.WeighingScales.Domain;

namespace Codprinter.WeighingScales.Application.Mappers;

public static class WeighingScaleUpdateMapper
{
    // Reuse la validación del dominio
    public static CreateWeighingScaleEntity ToDomain(this UpdateWeighingScaleRequest request, Guid userId)
    => new(
    name: request.Name,
    ip: request.IP,
    port: request.Port,
    userId: userId);

    public static void ApplyTo(this CreateWeighingScaleEntity domain, WeighingScale existing)
    {
        existing.WeighingScaleName = domain.Name;
        existing.WeighingScaleIp = domain.IP;
        existing.WeighingScalePort = domain.Port;
    }
}
