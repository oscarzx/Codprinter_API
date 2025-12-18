using Codprinter.Labels.Application.Dtos.GetLabel;
using Codprinter.Labels.Application.Interfaces.GetLabel;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.Mappers;
using Codprinter.Labels.Domain.Exceptions;

namespace Codprinter.Labels.Application.UsesCases;

internal sealed class GetLabelInteractor(
 ILabelTemplateRepository repository,
 IGetLabelOutputPort outputPort) : IGetLabelInputPort
{
    public async Task Handle(GetLabelRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.TemplateName))
            throw new InvalidLabelException("label.name.required", "Template name is required");

        var entity = await repository.GetByTemplateNameAsync(request.TemplateName.Trim());

        if (entity is null)
            throw new InvalidLabelException("label.not_found", $"Label template '{request.TemplateName}' was not found");

        var response = entity.ToGetLabelResponse();
        outputPort.Handle(response);
    }
}
