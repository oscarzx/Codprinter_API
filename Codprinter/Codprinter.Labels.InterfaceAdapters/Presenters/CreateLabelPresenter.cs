using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;

namespace Codprinter.Labels.InterfaceAdapters.Presenters;

internal class CreateLabelPresenter : ICreateLabelOutputPort
{
    public CreateLabelResponse Content { get; private set; } = default!;

    public Task Handle(CreateLabelResponse response)
    {
        Content = response;
        return Task.CompletedTask;
    }
}
