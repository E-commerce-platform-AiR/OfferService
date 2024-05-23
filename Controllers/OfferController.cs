using Microsoft.AspNetCore.Mvc;
using OfferService.Database.Entities;
using OfferService.Models;
using OfferService.Services.Interfaces;

namespace OfferService.Controllers;

[ApiController]
//[Route("offer")]
public class OfferController : ControllerBase
{
    private readonly IOfferService _offerService;
    public OfferController(IOfferService offerService)
    {
        _offerService = offerService;
    }
    
    [HttpPost("/users/{userId:guid}/offers")]
    public async Task<ActionResult<OfferEntity>> PostUser(Guid userId, [FromBody] Offer offer)
    {
        try
        {
            return Ok(await _offerService.PostOffer(userId, offer));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("/users/{userId:guid}/offer")]
    public async Task<ActionResult<OfferEntity>> GetUsersOffers(Guid userId)
    {
        try
        {
            return Ok(await _offerService.GetUsersOffers(userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("/offer")]
    public async Task<ActionResult<OfferEntity>> GetOffers(Guid userId)
    {
        try
        {
            return Ok(await _offerService.GetUsersOffers(userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    
    [HttpPatch("/users/{userId:guid}/offer/{offerId:long}")]
    public async Task<ActionResult<OfferEntity>> PatchOffer(Guid userId, long offerId, [FromBody] Offer offer)
    {
        try
        {
            return Ok(await _offerService.PatchOffer(userId, offerId, offer));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    [HttpDelete("/users/{userId:guid}/offer/{offerId:long}")]
    public async Task<ActionResult<bool>> DeleteOffer(Guid userId, long offerId)
    {
        try
        {
            return Ok(await _offerService.DeleteOffer(userId, offerId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}