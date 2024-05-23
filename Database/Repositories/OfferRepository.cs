using OfferService.Database.Repositories.Interfaces;
using OfferService.Database.DbContext;
using OfferService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using OfferService.Models.Exceptions;

namespace OfferService.Database.Repositories;

public class OfferRepository : IOfferRepository
{
    private readonly OfferDbContext _dbContext;

    public OfferRepository(OfferDbContext dbContext)
    {
        _dbContext = dbContext;
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
        return await _dbContext.Offers.Where(x => x.CreatedBy == userId).OrderByDescending(x => x.CreatedAt).Take(20).ToListAsync();
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
}