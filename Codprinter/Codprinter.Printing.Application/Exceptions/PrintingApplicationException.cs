namespace Codprinter.Printing.Application.Exceptions;

public sealed class PrintingApplicationException : Exception
{
    public PrintingApplicationException(string message, Exception? innerException = null) : base(message, innerException) { }
}
