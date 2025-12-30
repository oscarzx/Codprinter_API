namespace Codprinter.Printers.Application.Exceptions;

public abstract class PrinterExceptions : Exception
{
    protected PrinterExceptions(string message) : base(message)
    {
    }
}
