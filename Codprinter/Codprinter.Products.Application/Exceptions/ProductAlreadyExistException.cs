namespace Codprinter.Products.Application.Exceptions
{
    public sealed class ProductAlreadyExistException : ProductExceptions
    {
        public ProductAlreadyExistException(string message) : base(message)
        {
            
        }
    }
}
