namespace Codprinter.WeighingScales.Application.Exceptions
{
    public abstract class WeighingScaleException : Exception
    {
        protected WeighingScaleException(string message) : base(message)
        {
        }
    }
}
