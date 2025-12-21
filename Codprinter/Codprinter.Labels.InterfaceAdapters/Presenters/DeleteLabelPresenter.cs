using Codprinter.Labels.Application.Dtos.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;

namespace Codprinter.Labels.InterfaceAdapters.Presenters;

internal sealed class DeleteLabelPresenter : IDeleteLabelOutputPort
{
    public DeleteLabelResponse Content { get; private set; } = new();

    public Task Handle(DeleteLabelResponse response)
    {
        Content = response;
        return Task.CompletedTask;
    }
}
