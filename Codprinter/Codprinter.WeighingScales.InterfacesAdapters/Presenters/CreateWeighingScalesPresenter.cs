using Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale;

namespace Codprinter.WeighingScales.InterfacesAdapters.Presenters
{
    public sealed class CreateWeighingScalesPresenter : ICreateWeighingScaleOutputPort
    {
        public CreateWeighingScaleResponse Content { get; private set; } = default!;

        public Task Handle(CreateWeighingScaleResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
