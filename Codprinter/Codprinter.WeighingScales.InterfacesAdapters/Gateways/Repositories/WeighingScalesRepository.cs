using Codprinter.WeighingScales.Application.Interfaces.Repositories;
using Codprinter.WeighingScales.Application.POCOs;
using Codprinter.WeighingScales.InterfacesAdapters.Gateways.Interfaces;

namespace Codprinter.WeighingScales.InterfacesAdapters.Gateways.Repositories
{
    internal class WeighingScalesRepository(
        ICodprinterWeighingScaleCommandsDataContext context) : IWeighingScaleRepository
    {
        public async Task AddAsync(WeighingScale weighingScale)
            => await context.AddWeighingScaleAsync(weighingScale);

        public async Task<bool> ExistsAsync(string weighingScaleIp)
            => await context.ExistsWeighingScaleAsync(weighingScaleIp);

        public async Task<IReadOnlyList<WeighingScale>> GetAllAsync()
            => await context.GetAllWeighingScalesAsync();

        public async Task<WeighingScale?> GetByIdAsync(Guid id)
            => await context.GetByIdAsync(id);

        public async Task<bool> NameExistsAsync(string weighingScaleName, Guid? excludeId = null)
            => await context.NameExistsAsync(weighingScaleName, excludeId);

        public async Task<bool> IpExistsAsync(string weighingScaleIp, Guid? excludeId = null)
            => await context.IpExistsAsync(weighingScaleIp, excludeId);

        public Task UpdateAsync(WeighingScale weighingScale)
        {
            context.UpdateWeighingScale(weighingScale);
            return Task.CompletedTask;
        }

        public async Task SaveChanges()
            => await context.SaveChangesAsync();
    }
}
