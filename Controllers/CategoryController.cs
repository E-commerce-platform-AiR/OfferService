using Microsoft.AspNetCore.Mvc;
using OfferService.Database.Entities;
using OfferService.Database.Repositories.Interfaces;
using OfferService.Models;
using OfferService.Models.Exceptions;
using OfferService.Services.Interfaces;


namespace OfferService.Controllers;

[ApiController]
[Route("category")]
public class CategoryController
{
    private readonly IOfferService _offerService; // poprawic dodac category service
    
    public CategoryController(IOfferService categoryService)
    {
        _offerService = categoryService;
    }
    
    
}