using Codprinter.Labels.Application.Dtos.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Domain.Exceptions;

namespace Codprinter.Labels.Application.UsesCases;

internal sealed class DeleteLabelInteractor(
 ILabelTemplateRepository repository,
 IDeleteLabelOutputPort outputPort) : IDeleteLabelInputPort
{
    public async Task Handle(DeleteLabelRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.TemplateName))
            throw new InvalidLabelException("label.name.required", "Template name is required");

        var trimmedName = request.TemplateName.Trim();

        // Verificar existencia primero para poder lanzar una excepción semántica
        var existing = await repository.GetByTemplateNameAsync(trimmedName);
        if (existing is null)
            throw new LabelNotFoundException("label.not_found", $"Label template '{trimmedName}' was not found.");

        // Delegar el borrado lógico al repositorio
        await repository.DeleteByNameAsync(trimmedName);
        await repository.SaveChanges();

        var response = new DeleteLabelResponse
        {
            TemplateName = trimmedName,
            Message = "Etiqueta eliminada correctamente."
        };

        await outputPort.Handle(response);
    }
}
