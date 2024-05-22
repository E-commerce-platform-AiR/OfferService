namespace OfferService.Database.Entities;

public class OfferEntity
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public Uri? Logo;
    public double Price { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}