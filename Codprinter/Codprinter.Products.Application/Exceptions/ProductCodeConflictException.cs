namespace Codprinter.Products.Application.Exceptions;

public sealed class ProductCodeConflictException : Exception
{
    public ProductCodeConflictException(string message) : base(message) { }
}
