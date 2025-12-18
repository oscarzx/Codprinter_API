using Codprinter.Labels.Application.Dtos.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.Mappers;

namespace Codprinter.Labels.Application.UsesCases;

internal sealed class GetAllLabelsInteractor(
 ILabelTemplateRepository repository,
 IGetAllLabelsOutputPort outputPort) : IGetAllLabelsInputPort
{
    public async Task Handle(GetAllLabelsRequest request)
    {
        var summaries = await repository.GetAllSummariesAsync(request.OnlyActive);
        var response = summaries.ToGetAllLabelsResponse();
        outputPort.Handle(response);
    }
}
