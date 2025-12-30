namespace Codprinter.WeighingScales.Application.Dtos.CreateWeighingScale
{
    public class CreateWeighingScaleRequest
    {
        public string WeighingScaleName { get; set; }
        public string WeighingScaleIp { get; set; }
        public int WeighingScalePort { get; set; }
    }
}
