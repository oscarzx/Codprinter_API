using Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.POCOs;

namespace Codprinter.WeighingScales.Application.Mappers;

public static class WeighingScaleListMapper
{
    public static GetAllWeighingScalesResponse ToGetAllWeighingScalesResponse(this IReadOnlyList<WeighingScale> weighingScales)
    {
        var response = new GetAllWeighingScalesResponse();

        if (weighingScales is null || weighingScales.Count == 0)
            return response;

        foreach (var ws in weighingScales.OrderBy(x => x.WeighingScaleName))
        {
            response.Items.Add(new WeighingScaleListItem
            {
                Id = ws.Id,
                Name = ws.WeighingScaleName,
                Ip = ws.WeighingScaleIp,
                Port = ws.WeighingScalePort,
                CreatedAt = ws.CreatedAt
            });
        }

        return response;
    }
}
