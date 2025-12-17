using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Repositories
{
    internal class LabelRepository(ICodprinterLabelCommandsDataContext dataContext) :
        ILabelRepository
    {
        public async Task AddAsync(Label label)
            => await dataContext.AddLabelAsync(label);

        public async Task SaveChanges() => await dataContext.SaveChangesAsync();
    }
}
