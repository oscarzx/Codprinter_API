using Codprinter.WeighingScales.Application.POCOs;
using Codprinter.WeighingScales.Domain;

namespace Codprinter.WeighingScales.Application.Mappers
{
    public static class WeighingScaleMapper
    {
        public static WeighingScale ToNewWeighingScale(this CreateWeighingScaleEntity entity)
            => new WeighingScale
            {
                Id = Guid.NewGuid(),
                CreateBy = entity.UserId,
                WeighingScaleIp = entity.IP,
                WeighingScalePort = entity.Port,
                WeighingScaleName = entity.Name,
                CreatedAt = DateTime.UtcNow
            };
    }
}
