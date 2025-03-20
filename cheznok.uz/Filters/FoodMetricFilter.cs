using cheznok.uz.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cheznok.uz.Filters;

public class FoodMetricFilter : Attribute, IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var userId = (int)context.HttpContext.Items["UserId"];

        var foodService = context.HttpContext.RequestServices.GetService<IFoodService>();

        var id = int.Parse(context.RouteData.Values["id"].ToString());

        await foodService.LogMealMetric(userId, id);
    }
}
