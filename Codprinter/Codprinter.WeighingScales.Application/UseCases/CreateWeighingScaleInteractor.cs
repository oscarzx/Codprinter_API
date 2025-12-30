using Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Exceptions;
using Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.Repositories;
using Codprinter.WeighingScales.Application.Mappers;
using Codprinter.WeighingScales.Domain;

namespace Codprinter.WeighingScales.Application.UseCases
{
    internal class CreateWeighingScaleInteractor(
        IWeighingScaleRepository repository,
        ICreateWeighingScaleOutputPort outputPort) : ICreateWeighingScaleInputPort
    {
        public async Task Handle(CreateWeighingScaleRequest request)
        {
            if (await repository.ExistsAsync(request.WeighingScaleIp))
            {
                throw new WeighingScaleAlreadyExistException("Ya existe una balanza con ese número de IP.");
            }

            Guid userId = Guid.NewGuid(); // This should be replaced with actual user ID retrieval logic
            var weighingScaleEntity = new CreateWeighingScaleEntity(
                request.WeighingScaleName,
                request.WeighingScaleIp,
                request.WeighingScalePort,
                userId);

            await repository.AddAsync(weighingScaleEntity.ToNewWeighingScale());
            await repository.SaveChanges();

            var response = new CreateWeighingScaleResponse
            {
                Message = "Balanza creada correctamente.",
            };
            await outputPort.Handle(response);
        }
    }
}
