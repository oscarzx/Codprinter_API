namespace Codprinter.WeighingScales.Domain.Exceptions
{
    public sealed class InvalidWeighingScaleException : Exception
    {
        public string Code { get; }
        public InvalidWeighingScaleException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
