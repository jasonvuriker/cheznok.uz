using cheznok.uz.Dtos;
using cheznok.uz.Filters;
using cheznok.uz.Services;
using Microsoft.AspNetCore.Mvc;

namespace cheznok.uz.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FoodItemController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodItemController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpPost("foods/add")]
    public async Task<IActionResult> AddFoodItem([FromBody] FoodItemDto foodItemDto)
    {
        await _foodService.AddFoodItem(foodItemDto);

        return Created();
    }

    [HttpGet("foods")]
    public async Task<IActionResult> GetFoodItems()
    {
        return Ok(await _foodService.GetAllFoods());
    }

    [HttpGet("foods/{id:int}")]
    [FoodMetricFilter]
    public async Task<IActionResult> GetFoodItem([FromRoute] int id)
    {
        return Ok(await _foodService.GetFood(id));
    }
}
