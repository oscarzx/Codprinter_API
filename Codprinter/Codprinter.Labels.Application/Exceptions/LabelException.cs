namespace Codprinter.Labels.Application.Exceptions;

public abstract class LabelException : Exception
{
    protected LabelException(string message) : base(message)
    {
    }
}
