namespace cheznok.uz.Entities;

public class MealLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FoodItemId { get; set; }
    public double Quantity { get; set; }
    public DateTime LoggedAt { get; set; }

    public User User { get; set; }
    public FoodItem FoodItem { get; set; }
}