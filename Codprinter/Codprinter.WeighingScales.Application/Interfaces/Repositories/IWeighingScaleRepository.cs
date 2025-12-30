using Codprinter.Shared.Application.UnitOfWork;
using Codprinter.WeighingScales.Application.POCOs;

namespace Codprinter.WeighingScales.Application.Interfaces.Repositories
{
    public interface IWeighingScaleRepository : IUnitOfWork
    {
        Task AddAsync(WeighingScale weighingScale);
        Task<bool> ExistsAsync(string weighingScaleIp);
        Task<IReadOnlyList<WeighingScale>> GetAllAsync();

        Task<WeighingScale?> GetByIdAsync(Guid id);
        Task<bool> NameExistsAsync(string weighingScaleName, Guid? excludeId = null);
        Task<bool> IpExistsAsync(string weighingScaleIp, Guid? excludeId = null);
        Task UpdateAsync(WeighingScale weighingScale);
    }
}
