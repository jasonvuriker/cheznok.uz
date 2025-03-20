using cheznok.uz.Enums;

namespace cheznok.uz.Dtos;

public class FoodItemDto
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fats { get; set; }
    public FoodCategory FoodCategory { get; set; }
}
