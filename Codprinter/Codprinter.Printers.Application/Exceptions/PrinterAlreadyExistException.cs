namespace Codprinter.Printers.Application.Exceptions;

public sealed class PrinterAlreadyExistException : PrinterExceptions
{
    public PrinterAlreadyExistException(string message) : base(message)
    {
    }
}
