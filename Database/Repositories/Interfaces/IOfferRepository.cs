using OfferService.Database.Entities;

namespace OfferService.Database.Repositories.Interfaces;

public interface IOfferRepository
{
    Task SaveAsync();
    Task InsertOfferAsync(OfferEntity offerEntity);
    Task<OfferEntity> GetOffer(Guid userId, long offerId);
    Task<IEnumerable<OfferEntity>> GetUsersOffers(Guid userId);
}