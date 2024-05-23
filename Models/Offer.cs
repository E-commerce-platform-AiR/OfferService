namespace OfferService.Models;

public class Offer
{
    public string Title { get; set; }
    public int Category { get; set; }
    public string? Description { get; set; }
    public Uri? Logo;
    public double Price { get; set; }
}