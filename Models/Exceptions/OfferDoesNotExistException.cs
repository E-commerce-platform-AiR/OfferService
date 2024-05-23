namespace OfferService.Models.Exceptions;

public class OfferDoesNotExistException : Exception
{
    public OfferDoesNotExistException() : base("Offer with this id does not exist") { }
    public OfferDoesNotExistException(string message) : base(message) { }
}