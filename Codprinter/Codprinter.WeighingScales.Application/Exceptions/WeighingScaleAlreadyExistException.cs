namespace Codprinter.WeighingScales.Application.Exceptions
{
    public sealed class WeighingScaleAlreadyExistException : WeighingScaleException
    {
        public WeighingScaleAlreadyExistException(string message) : base(message)
        {
        }
    }
}
