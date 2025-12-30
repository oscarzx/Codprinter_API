namespace Codprinter.Products.Application.Exceptions;

public abstract class ProductExceptions : Exception
{
    protected ProductExceptions(string message) : base(message)
    {
    }
}
