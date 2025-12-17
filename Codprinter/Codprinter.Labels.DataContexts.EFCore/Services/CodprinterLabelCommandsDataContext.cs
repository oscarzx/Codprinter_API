using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.DataContexts.EFCore.DataContexts;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Codprinter.Labels.DataContexts.EFCore.Services;

internal class CodprinterLabelCommandsDataContext(IOptions<DBOptions> options) :
    CodprinterLabelsContext(options),
    ICodprinterLabelCommandsDataContext

{
    public async Task AddLabelAsync(Label label) =>
        await AddAsync(label);

    public async Task SaveChangesAsync() => await base.SaveChangesAsync();
}
