namespace Codprinter.Labels.Application.Dtos.GetAllLabels;

public class GetAllLabelsResponse
{
    public List<LabelSummaryItem> Items { get; set; } = new();
}

public class LabelSummaryItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Dpi { get; set; }
    public string Units { get; set; } = string.Empty;
    public decimal WidthMm { get; set; }
    public decimal HeightMm { get; set; }
    public bool IsActive { get; set; }
}
