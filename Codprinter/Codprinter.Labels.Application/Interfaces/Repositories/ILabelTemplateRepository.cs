using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Labels.Domain;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Labels.Application.Interfaces.Repositories
{
    public interface ILabelTemplateRepository : IUnitOfWork
    {
        Task AddAsync(LabelTemplateAggregate aggregate);

        Task<LabelEntity?> GetByTemplateNameAsync(string templateName);

        Task<IReadOnlyList<LabelTemplateSummary>> GetAllSummariesAsync(bool onlyActive);

        /// <summary>
        /// Updates an existing label template aggregate. The implementation is responsible for
        /// applying the changes to the existing rows (template, variables, elements, assets)
        /// rather than inserting a new template.
        /// </summary>
        Task UpdateAsync(LabelTemplateAggregate aggregate);

        /// <summary>
        /// Performs a logical delete (soft delete) of a label template by its name.
        /// Implementations may choose to set IsActive = false or similar semantics.
        /// </summary>
        Task DeleteByNameAsync(string templateName);
    }
}
