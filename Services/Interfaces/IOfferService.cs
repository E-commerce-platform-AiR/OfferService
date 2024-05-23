using OfferService.Database.Entities;
using OfferService.Models;

namespace OfferService.Services.Interfaces;
public interface IOfferService
{
    Task<OfferEntity> PostOffer(Guid userId, Offer offer);
    Task<IEnumerable<OfferEntity>> GetUsersOffers(Guid userId);
    Task<bool> DeleteOffer(Guid userId, long offerId);
    Task<OfferEntity> PatchOffer(Guid userId, long offerId, Offer offer);
}