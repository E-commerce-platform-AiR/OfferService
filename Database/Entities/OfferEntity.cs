﻿using OfferService.Models;

namespace OfferService.Database.Entities;

public class OfferEntity
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Category { get; set; }
    public string? Description { get; set; }
    public Uri? Logo;
    public double Price { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }

    public OfferEntity(Offer offer)
    {
        Title = offer.Title;
        Description = offer.Description;
        Logo = offer.Logo;
        Price = offer.Price;
    }

    public OfferEntity() { }
}