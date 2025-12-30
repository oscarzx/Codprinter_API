using Codprinter.WeighingScales.Application.POCOs;

namespace Codprinter.WeighingScales.InterfacesAdapters.Gateways.Interfaces
{
    public interface ICodprinterWeighingScaleCommandsDataContext
    {
        Task AddWeighingScaleAsync(WeighingScale weighingScale);
        Task<bool> ExistsWeighingScaleAsync(string weighingScaleIp);
        Task<IReadOnlyList<WeighingScale>> GetAllWeighingScalesAsync();

        // Queries necesarias para update
        Task<WeighingScale?> GetByIdAsync(Guid id);
        Task<bool> IpExistsAsync(string ip, Guid? excludeId = null);
        Task<bool> NameExistsAsync(string name, Guid? excludeId = null);

        // Commands
        void UpdateWeighingScale(WeighingScale weighingScale);
        Task SaveChangesAsync();
    }
}
