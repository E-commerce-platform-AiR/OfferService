using Microsoft.AspNetCore.Mvc;
using OfferService.Database.Entities;
using OfferService.Models;
using OfferService.Services.Interfaces;

namespace OfferService.Controllers;

[ApiController]
//[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService; // poprawic dodac category service
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("/user/{userId:Guid}/category")]
    public async Task<ActionResult<OfferEntity>> PostCategory(Guid userId, [FromBody] Category category)
    {
        try
        {
            return Ok(await _categoryService.PostCategory(userId, category));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("/categories")]
    public async Task<ActionResult<OfferEntity>> GetCategories()
    {
        try
        {
            return Ok(await _categoryService.GetCategories());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}