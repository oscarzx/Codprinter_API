namespace Codprinter.WeighingScales.Application.Dtos.UpdateWeighingScale;

public class UpdateWeighingScaleRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IP { get; set; } = string.Empty;
    public int Port { get; set; }
}
