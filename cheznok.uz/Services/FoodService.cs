using cheznok.uz.Dtos;
using cheznok.uz.Entities;
using cheznok.uz.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace cheznok.uz.Services;

public interface IFoodService
{
    Task AddFoodItem(FoodItemDto foodItem);

    Task<IEnumerable<FoodItemDto>> GetAllFoods();

    Task<FoodItemDto> GetFood(int id);

    Task LogMealMetric(int userId, int foodItemId);
}

public class FoodService : IFoodService
{
    private readonly ChesnokContext _context;

    public FoodService(ChesnokContext context)
    {
        _context = context;
    }

    public async Task AddFoodItem(FoodItemDto foodItemDto)
    {
        var foodItem = new FoodItem
        {
            Name = foodItemDto.Name,
            Calories = foodItemDto.Calories,
            Carbs = foodItemDto.Carbs,
            Fats = foodItemDto.Fats,
            FoodCategory = foodItemDto.FoodCategory,
            Protein = foodItemDto.Protein
        };
        await _context.FoodItems.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FoodItemDto>> GetAllFoods()
    {
        return _context.FoodItems.AsNoTracking().Select(r => new FoodItemDto
        {
            Name = r.Name,
            Calories = r.Calories,
            Carbs = r.Carbs,
            Fats = r.Fats,
            FoodCategory = r.FoodCategory,
            Protein = r.Protein
        });
    }

    public async Task<FoodItemDto> GetFood(int id)
    {
        var entity = await _context.FoodItems.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);

        return new FoodItemDto()
        {
            Name = entity.Name,
            Calories = entity.Calories,
            Carbs = entity.Carbs,
            Fats = entity.Fats,
            FoodCategory = entity.FoodCategory,
            Protein = entity.Protein
        };
    }

    public async Task LogMealMetric(int userId, int foodItemId)
    {
        var metricLog = new MealLog()
        {
            UserId = userId,
            FoodItemId = foodItemId,
            LoggedAt = DateTime.UtcNow,
        };

        await _context.MealLogs.AddAsync(metricLog);
        await _context.SaveChangesAsync();
    }
}
