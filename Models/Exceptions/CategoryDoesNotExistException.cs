namespace OfferService.Models.Exceptions;

public class CategoryDoesNotExistException : Exception
{
    public CategoryDoesNotExistException() : base("This category does not exist.") { }
    public CategoryDoesNotExistException(string message) : base(message) { }
}