namespace Codprinter.WeighingScales.Domain.ValueObjects
{
    public class Endpoints
    {
        public const string CreateWeighingScale = $"/{nameof(CreateWeighingScale)}";
        public const string GetWeighingScaleById = $"/{nameof(GetWeighingScaleById)}";
        public const string GetWeighingScaleByName = $"/{nameof(GetWeighingScaleByName)}";
        public const string GetWeighingScaleByIp = $"/{nameof(GetWeighingScaleByIp)}";
        public const string GetAllWeighingScales = $"/{nameof(GetAllWeighingScales)}";
        public const string UpdateWeighingScale = $"/{nameof(UpdateWeighingScale)}";
        public const string DeleteWeighingScale = $"/{nameof(DeleteWeighingScale)}";
    }
}
