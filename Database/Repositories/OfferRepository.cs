﻿using OfferService.Database.Repositories.Interfaces;
using OfferService.Database.DbContext;
using OfferService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using OfferService.Models;
using OfferService.Models.Exceptions;

namespace OfferService.Database.Repositories;

public sealed class OfferRepository : IOfferRepository
{
    private readonly OfferDbContext _dbContext;
    private readonly ICategoryRepository _categoryRepository;

    public OfferRepository(OfferDbContext dbContext, ICategoryRepository categoryRepository)
    {
        _dbContext = dbContext;
        _categoryRepository = categoryRepository;
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public async Task InsertOfferAsync(OfferEntity offerEntity)
    {
        await _dbContext.Offers.AddAsync(offerEntity); 
    }

    public async Task<IEnumerable<OfferEntity>> GetUsersOffers(Guid userId)
    {
        return await _dbContext.Offers.Where(x => x.CreatedBy == userId && x.IsDeleted == false).OrderByDescending(x => x.CreatedAt).Take(20).ToListAsync();
    }

    public async Task<IEnumerable<OfferEntity>> GetOffers()
    {
        return await _dbContext.Offers.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<OfferEntity> GetOffer(Guid userId, long offerId)
    {
        OfferEntity? offerEntity =  await _dbContext.Offers.Where(x => x.Id == offerId && x.CreatedBy == userId).FirstOrDefaultAsync();
        if (offerEntity == null)
        {
            throw new OfferDoesNotExistException();
        }
        
        return offerEntity;
    }

    public async Task<IEnumerable<OfferResponse>> GetOfferByCategory(int categoryId)
    {
        var offers = await _dbContext.Offers.Where(x => x.CategoryId == categoryId && x.IsDeleted == false).ToListAsync();
        var categories = await _dbContext.Category.ToDictionaryAsync(c => c.Id, c => c.Name);

        var offerResponses = offers.Select(offer => new OfferResponse(offer)
        {
            Category = categories.ContainsKey(offer.CategoryId) ? categories[offer.CategoryId] : "Unknown"
        }).ToList();

        return offerResponses;
    }


}