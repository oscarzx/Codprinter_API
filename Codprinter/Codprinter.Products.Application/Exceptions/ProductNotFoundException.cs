namespace Codprinter.Products.Application.Exceptions;

public sealed class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message) { }
}
