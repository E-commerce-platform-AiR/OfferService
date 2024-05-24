using OfferService.Database.Entities;
using OfferService.Database.Repositories.Interfaces;
using OfferService.Models;
using OfferService.Services.Interfaces;

namespace OfferService.Services;

public class OfferService : IOfferService
{
    private readonly IOfferRepository _offerRepository;
    private readonly ICategoryRepository _categoryRepository;
    
    public OfferService(IOfferRepository offerRepository, ICategoryRepository categoryRepository)
    {
        _offerRepository = offerRepository;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<OfferEntity> PostOffer(Guid userId, Offer offer)
    {
        OfferEntity offerEntity = new(offer)
        {
            Id = new long(),
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = userId
        };

        await _offerRepository.InsertOfferAsync(offerEntity);
        await _offerRepository.SaveAsync();

        return offerEntity;
    }
    
    public async Task<OfferEntity> PatchOffer(Guid userId, long offerId, Offer offer)
    {

        CategoryEntity categoryEntity = await _categoryRepository.GetCategoryByName(offer.Category);
        
        OfferEntity offerEntity = await _offerRepository.GetOffer(userId, offerId);
        offerEntity.Title = offer.Title;
        offerEntity.Category = categoryEntity.Id;
        offerEntity.Description = offer.Description;
        offerEntity.Price = offer.Price;
        offerEntity.ModifiedAt = DateTimeOffset.UtcNow;
        await _offerRepository.SaveAsync();

        return offerEntity;
    }

    public async Task<IEnumerable<OfferEntity>> GetUsersOffers(Guid userId)
    {
        return await _offerRepository.GetUsersOffers(userId);
    }
    
    public async Task<bool> DeleteOffer(Guid userId, long offerId)
    {
        OfferEntity offerEntity = await _offerRepository.GetOffer(userId, offerId);
        offerEntity.IsDeleted = true;
        await _offerRepository.SaveAsync();

        return true;
    }
}