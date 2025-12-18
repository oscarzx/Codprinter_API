using Codprinter.Labels.Application.Dtos.GetAllLabels;
using Codprinter.Labels.Domain;

namespace Codprinter.Labels.Application.Mappers;

public static class LabelListMapper
{
    public static GetAllLabelsResponse ToGetAllLabelsResponse(this IReadOnlyList<LabelTemplateSummary> summaries)
    {
        var response = new GetAllLabelsResponse();

        foreach (var s in summaries)
        {
            response.Items.Add(new LabelSummaryItem
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Dpi = s.Dpi,
                Units = s.Units,
                WidthMm = s.WidthMm,
                HeightMm = s.HeightMm,
                IsActive = s.IsActive
            });
        }

        return response;
    }
}
