using Codprinter.Shared.Infrastructure.Options;
using Codprinter.WeighingScales.Application.POCOs;
using Codprinter.WeighingScales.DataCOntexts.EFCore.DataContexts;
using Codprinter.WeighingScales.InterfacesAdapters.Gateways.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Codprinter.WeighingScales.DataCOntexts.EFCore.Services
{
    internal sealed class CodprinterWeighingScalesCommandsDataContext(IOptions<DBOptions> options) :
        CodprinterWeighingScalesContextx(options),
        ICodprinterWeighingScaleCommandsDataContext
    {
        public async Task AddWeighingScaleAsync(WeighingScale weighingScale)
            => await AddAsync(weighingScale);

        public async Task<bool> ExistsWeighingScaleAsync(string weighingScaleIp)
            => await WeighingScales.AnyAsync(ws => ws.WeighingScaleIp == weighingScaleIp);

        public async Task<IReadOnlyList<WeighingScale>> GetAllWeighingScalesAsync()
            => (IReadOnlyList<WeighingScale>)await WeighingScales.AsNoTracking().ToListAsync();

        public async Task<WeighingScale?> GetByIdAsync(Guid id)
            => await WeighingScales.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> IpExistsAsync(string ip, Guid? excludeId = null)
        {
            var q = WeighingScales.AsNoTracking().Where(x => x.WeighingScaleIp == ip);
            if (excludeId.HasValue && excludeId.Value != Guid.Empty)
                q = q.Where(x => x.Id != excludeId.Value);
            return await q.AnyAsync();
        }

        public async Task<bool> NameExistsAsync(string name, Guid? excludeId = null)
        {
            var q = WeighingScales.AsNoTracking().Where(x => x.WeighingScaleName == name);
            if (excludeId.HasValue && excludeId.Value != Guid.Empty)
                q = q.Where(x => x.Id != excludeId.Value);
            return await q.AnyAsync();
        }

        public void UpdateWeighingScale(WeighingScale weighingScale)
            => Update(weighingScale);

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
