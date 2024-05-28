﻿using OfferService.Database.Entities;
using OfferService.Models;

namespace OfferService.Database.Repositories.Interfaces;

public interface IOfferRepository
{
    Task SaveAsync();
    Task InsertOfferAsync(OfferEntity offerEntity);
    Task<IEnumerable<OfferEntity>> GetOffers();
    Task<OfferEntity> GetOffer(long offerId);
    Task<OfferEntity> GetOffer(Guid userId, long offerId);
    Task<IEnumerable<OfferEntity>> GetUsersOffers(Guid userId);
    Task<IEnumerable<OfferResponse>> GetOfferByCategory(int categoryId);
}