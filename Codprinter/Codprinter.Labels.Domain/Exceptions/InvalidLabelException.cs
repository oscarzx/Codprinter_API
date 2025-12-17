namespace Codprinter.Labels.Domain.Exceptions
{
    public sealed class InvalidLabelException : DomainException
    {
        public InvalidLabelException(string code, string message) : base(code, message)
        {
        }
    }
}
