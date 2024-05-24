using OfferService.Database.Entities;

namespace OfferService.Database.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryEntity> GetCategoryByName(string categoryName);
    Task<IEnumerable<CategoryEntity>> GetCategories();
    Task InsertCategoryAsync(CategoryEntity categoryEntity);
    Task SaveAsync();
}