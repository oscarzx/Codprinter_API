using Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.Repositories;
using Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.Mappers;
using Codprinter.WeighingScales.Domain.Exceptions;

namespace Codprinter.WeighingScales.Application.UseCases;

internal sealed class UpdateWeighingScaleInteractor(
 IWeighingScaleRepository repository,
 IUpdateWeighingScaleOutputPort outputPort) : IUpdateWeighingScaleInputPort
{
    public async Task Handle(UpdateWeighingScaleRequest request)
    {
        if (request.Id == Guid.Empty)
            throw new InvalidWeighingScaleException("weighingscale.id.required", "El Id es requerido.");

        var existing = await repository.GetByIdAsync(request.Id);
        if (existing is null)
            throw new InvalidWeighingScaleException("weighingscale.not_found", $"No existe una balanza con id '{request.Id}'.");

        // TODO: reemplazar por el usuario actual (auth/session). Se mantiene CreateBy por compatibilidad.
        var userId = existing.CreateBy;
        var domain = request.ToDomain(userId);

        if (await repository.IpExistsAsync(domain.IP, excludeId: existing.Id))
            throw new InvalidWeighingScaleException("weighingscale.ip.conflict", "Ya existe una balanza con esa IP.");

        if (await repository.NameExistsAsync(domain.Name, excludeId: existing.Id))
            throw new InvalidWeighingScaleException("weighingscale.name.conflict", "Ya existe una balanza con ese nombre.");

        domain.ApplyTo(existing);

        await repository.UpdateAsync(existing);
        await repository.SaveChanges();

        outputPort.Handle(new UpdateWeighingScaleResponse
        {
            Message = "Balanza actualizada correctamente."
        });
    }
}
