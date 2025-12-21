namespace Codprinter.Labels.Domain;

public class UpdateLabelTemplateData
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Dpi { get; set; }
    public string Units { get; set; } = string.Empty; // 'mm','in'
    public decimal WidthMm { get; set; }
    public decimal HeightMm { get; set; }
    public string RawJson { get; set; } = string.Empty;
    public string? ElementsJson { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedByUserId { get; set; }
}
