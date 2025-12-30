namespace Codprinter.WeighingScales.Application.POCOs
{
    public class WeighingScale
    {
        public Guid Id { get; set; }
        public Guid CreateBy { get; set; }
        public string WeighingScaleName { get; set; }
        public string WeighingScaleIp { get; set; }
        public int WeighingScalePort { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
