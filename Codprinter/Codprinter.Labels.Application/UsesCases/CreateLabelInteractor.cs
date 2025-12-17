using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.Mappers;
using Codprinter.Labels.Domain;

namespace Codprinter.Labels.Application.UsesCases;

internal class CreateLabelInteractor(
    ILabelTemplateRepository repository,
    ICreateLabelOutputPort outputPort) : ICreateLabelInputPort
{
    public async Task Handle(CreateLabelRequest request)
    {
        // Build domain aggregate (validates with InvalidLabelException if bad)
        var entity = request.ToDomainEntity();

        // Map to persistence aggregate and save
        var aggregate = entity.ToPersistenceAggregate();
        await repository.AddAsync(aggregate);
        await repository.SaveChanges();

        var response = new CreateLabelResponse
        {
            Message = "Etiqueta creada correctamente.",
        };
        outputPort.Handle(response);
    }
}
