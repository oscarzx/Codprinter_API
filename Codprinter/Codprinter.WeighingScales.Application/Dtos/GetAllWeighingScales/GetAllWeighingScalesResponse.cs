namespace Codprinter.WeighingScales.Application.Dtos.GetAllWeighingScales;

public class GetAllWeighingScalesResponse
{
    public List<WeighingScaleListItem> Items { get; set; } = new();
}

public class WeighingScaleListItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public int Port { get; set; }
    public DateTime CreatedAt { get; set; }
}
