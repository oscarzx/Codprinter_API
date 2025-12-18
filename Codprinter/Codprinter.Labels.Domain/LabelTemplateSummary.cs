using Codprinter.Labels.Domain.Exceptions;

namespace Codprinter.Labels.Domain;

/// <summary>
/// Lightweight domain DTO to represent label templates in list views.
/// </summary>
public sealed class LabelTemplateSummary
{
    public Guid Id { get; }
    public string Name { get; }
    public string? Description { get; }
    public int Dpi { get; }
    public string Units { get; }
    public decimal WidthMm { get; }
    public decimal HeightMm { get; }
    public bool IsActive { get; }

    public LabelTemplateSummary(
    Guid id,
    string name,
    string? description,
    int dpi,
    string units,
    decimal widthMm,
    decimal heightMm,
    bool isActive)
    {
        if (id == Guid.Empty)
            throw new InvalidLabelException("label.id.invalid", "Label template id is required");

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidLabelException("label.name.required", "Template name is required");

        Id = id;
        Name = name.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description;
        Dpi = dpi;
        Units = units;
        WidthMm = widthMm;
        HeightMm = heightMm;
        IsActive = isActive;
    }
}
